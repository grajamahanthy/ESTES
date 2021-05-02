using IntegrationLib.Common.Classes;
using IntegrationLib.IntegrationHelpers;
using IntegrationLib.VendorClasses.SuperVision.MVR;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IntegrationLib.Common
{
    class FtpHelper : FtpModel
    {
        //Our single instance of the singleton
        private static FtpHelper instance = null;
        private static LoggerHelper logger = null;
        public static Config config = null;
        //Private constructor to deny instance creation of this class from outside
        private FtpHelper()
        {
        }

        //GetInstace method to be used to create or reach the single resource (instance)
        public static FtpHelper GetInstance(Config _config)
        {
            try
            {
                config = _config;
                logger = LoggerHelper.GetInstance(config);
                if (instance == null)
                {
                    var LogResource = (from R in config.Resources where R.ResourceType == "Location" && R.Name == "Source" select R).ToList().FirstOrDefault();

                    if (LogResource.LocationType == "FTP")
                    {
                        instance = new FtpHelper();
                        instance.Host = LogResource.Ftp.Host;
                        instance.UserName = EncryptionHelper.Decrypt(LogResource.Ftp.UserName);
                        instance.Password = EncryptionHelper.Decrypt(LogResource.Ftp.Password);
                        if (!string.IsNullOrEmpty(LogResource.Ftp.KeyFilePath))
                            instance.KeyFilePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), LogResource.Ftp.KeyFilePath); //Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"Keys\Private-OpenSSH");
                        instance.FtpFolderPath = LogResource.Ftp.FtpFolderPath;
                        instance.LocalTempProcDirectory = LogResource.Ftp.LocalTempProcDirectory; //LogResource.Ftp.LocalTempProcDirectory;
                    }
                }
                return instance;
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        //Implement functionality as public instance methods
        public static async Task ProcessFtpData(Func<string, Task<bool>> ExecIntegrationSteps)
        {
            try
            {
                string isProd = ConfigurationManager.AppSettings["isProd"].ToString();
                if (isProd == "1")
                {
                    PrivateKeyFile keyFile = null;
                    if (!string.IsNullOrEmpty(instance.KeyFilePath))
                        keyFile = new PrivateKeyFile(instance.KeyFilePath);

                    var keyFiles = new[] { keyFile };
                    var methods = new List<AuthenticationMethod>();
                    methods.Add(new PasswordAuthenticationMethod(instance.UserName, instance.Password));

                    if (!string.IsNullOrEmpty(instance.KeyFilePath))
                        methods.Add(new PrivateKeyAuthenticationMethod(instance.UserName, keyFiles));

                    ConnectionInfo con = new ConnectionInfo(instance.Host, 22, instance.UserName, methods.ToArray());
                    using (var sftp = new SftpClient(con))
                    {
                        sftp.Connect();
                        var files = sftp.ListDirectory(instance.FtpFolderPath);
                        var atleastOneFileProcessed = false;

                        foreach (SftpFile file in files)
                        {
                            if (!file.IsDirectory && !file.Name.ToLower().Contains("success")
                                && !file.Name.ToLower().Contains("error") && file.Name.ToLower().EndsWith(".xml"))
                            {
                                string sourceXml = string.Empty;
                                bool isExecSuccess = false;
                                atleastOneFileProcessed = true;
                                using (Stream localFile = File.Open(instance.LocalTempProcDirectory + file.Name, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                {

                                    //Load Xml file from FTP.
                                    sftp.DownloadFile(instance.FtpFolderPath + file.Name, localFile);
                                    string xmlString = string.Empty;
                                    var xmlDoc = new XmlDocument();
                                    xmlDoc.Load(sftp.OpenRead(instance.FtpFolderPath + file.Name));
                                    sourceXml = xmlDoc.InnerXml;
                                    SerializationHelper sH = new SerializationHelper();
                                    MVRReports mR = sH.Deserialize<MVRReports>(sourceXml);

                                    //Log FirstName, LastName, Resume Key
                                    string titleHtml = "<br/><br/>" + "<b>File Name: </b>" + file.Name + "<br/>" + "<b>First Name: </b>" + mR.MVRReport.Driver.FirstName + "<br/>";
                                    if (!string.IsNullOrEmpty(mR.MVRReport.Driver.MiddleName))
                                        titleHtml = titleHtml + "<b>Middle Name: </b>" + mR.MVRReport.Driver.MiddleName + "<br/>";
                                    titleHtml = titleHtml + "<b>Last Name: </b>" + mR.MVRReport.Driver.LastName + "<br/>" + "<b>Resume key: </b>" + mR.MVRReport.Driver.DriverReferenceNumber;

                                    logger.Log(LogType.Html, titleHtml);


                                    //Process XML
                                    if (!string.IsNullOrEmpty(mR.MVRReport.Driver.FirstName) &&
                                       !string.IsNullOrEmpty(mR.MVRReport.Driver.LastName) &&
                                       !string.IsNullOrEmpty(Convert.ToString(mR.MVRReport.Driver.DriverReferenceNumber)) &&
                                       !string.IsNullOrEmpty(mR.MVRReport.Quoteback))
                                    {
                                        isExecSuccess = await ExecIntegrationSteps(sourceXml);
                                    }
                                    else
                                    {
                                        isExecSuccess = false;
                                        logger.Log(LogType.Error, file.Name + " doesn't have First name, Last name, Auto ReqId, or ResumeKey.");
                                    }
                                }

                                //Move the Source XML to Success/Error folder after process.
                                if (isExecSuccess)
                                {
                                    logger.Log(LogType.Success, file.Name + " is processed successfully.");
                                    MoveToFtpLocation(file.Name, "SuccessLocation", "Location");

                                    //To be removed--sftp.UploadFile(localFile, instance.SuccessFolderPath + file.Name, true);
                                    //To be Uncommented--
                                    sftp.RenameFile(instance.FtpFolderPath + file.Name, instance.FtpFolderPath + file.Name.Replace(".xml", $"_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}_success.xml"));
                                }
                                else
                                {
                                    logger.Log(LogType.Error, file.Name + " is not processed successfully.");
                                    MoveToFtpLocation(file.Name, "ErrorLocation", "Location");

                                    //To be removed--sftp.UploadFile(localFile, instance.ErrorFolderPath + file.Name, true);
                                    //To be Uncommented--
                                    sftp.RenameFile(instance.FtpFolderPath + file.Name, instance.FtpFolderPath + file.Name.Replace(".xml", $"_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}_error.xml"));
                                }

                                //Delete the Source XML from FTP after process.
                                //sftp.DeleteFile(instance.FtpFolderPath + file.Name);

                            }
                        }


                        logger.Log(LogType.Html, (!atleastOneFileProcessed ? "No MVR reports are available for processing." : "") + "</body></html>", null, true);
                        sftp.Disconnect();
                    }
                }
                else
                {
                    
                    var resource = (from R in config.Resources where R.ResourceType == "Location" && R.Name == "LocalSource" select R).ToList().FirstOrDefault();
                    string[] files;
                    files = Directory.GetFiles(resource.File.Path, "*.xml");
                    var atleastOneFileProcessed = false;

                    foreach (string file in files)
                    {
                        if (!file.ToLower().Contains("success")
                            && !file.ToLower().Contains("error"))
                        {
                            string sourceXml = string.Empty;
                            bool isExecSuccess = false;
                            atleastOneFileProcessed = true;


                            //Load Xml file from FTP.
                            string xmlString = string.Empty;
                            var xmlDoc = new XmlDocument();
                            xmlDoc.Load(file);
                            sourceXml = xmlDoc.InnerXml;
                            SerializationHelper sH = new SerializationHelper();
                            MVRReports mR = sH.Deserialize<MVRReports>(sourceXml);

                            //Log FirstName, LastName, Resume Key
                            string titleHtml = "<br/><br/>" + "<b>File Name: </b>" + file + "<br/>" + "<b>First Name: </b>" + mR.MVRReport.Driver.FirstName + "<br/>";
                            if (!string.IsNullOrEmpty(mR.MVRReport.Driver.MiddleName))
                                titleHtml = titleHtml + "<b>Middle Name: </b>" + mR.MVRReport.Driver.MiddleName + "<br/>";
                            titleHtml = titleHtml + "<b>Last Name: </b>" + mR.MVRReport.Driver.LastName + "<br/>" + "<b>Resume key: </b>" + mR.MVRReport.Driver.DriverReferenceNumber;

                            logger.Log(LogType.Html, titleHtml);


                            //Process XML
                            if (!string.IsNullOrEmpty(mR.MVRReport.Driver.FirstName) &&
                                !string.IsNullOrEmpty(mR.MVRReport.Driver.LastName) &&
                                !string.IsNullOrEmpty(Convert.ToString(mR.MVRReport.Driver.DriverReferenceNumber)) &&
                                !string.IsNullOrEmpty(mR.MVRReport.Quoteback))
                            {
                                isExecSuccess = await ExecIntegrationSteps(sourceXml);
                            }
                            else
                            {
                                isExecSuccess = false;
                                logger.Log(LogType.Error, file + " doesn't have First name, Last name, Auto ReqId, or ResumeKey.");
                            }

                            //Move the Source XML to Success/Error folder after process.
                            if (isExecSuccess)
                            {
                                logger.Log(LogType.Success, file + " is processed successfully.");
                                MoveToFtpLocation(file, "SuccessLocation", "Location");

                                //To be removed--sftp.UploadFile(localFile, instance.SuccessFolderPath + file.Name, true);
                                //To be Uncommented--
                                File.Move(file, file.Replace(".xml", $"_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}_success.xml"));
                            }
                            else
                            {
                                logger.Log(LogType.Error, file + " is not processed successfully.");
                                MoveToFtpLocation(file, "ErrorLocation", "Location");

                                //To be removed--sftp.UploadFile(localFile, instance.ErrorFolderPath + file.Name, true);
                                //To be Uncommented--
                                File.Move(file, file.Replace(".xml", $"_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}_error.xml"));
                            }

                            //Delete the Source XML from FTP after process.
                            //sftp.DeleteFile(instance.FtpFolderPath + file.Name);

                        }
                    }


                    logger.Log(LogType.Html, (!atleastOneFileProcessed ? "No MVR reports are available for processing." : "") + "</body></html>", null, true);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Html, ex.Message + "</body></html>", null, true);
            }
        }


        public static void MoveToFtpLocation(string fileName, string ResourceName, string ResourceType)
        {
            try
            {
                var resource = (from R in config.Resources where R.ResourceType == ResourceType && R.Name == ResourceName select R).ToList().FirstOrDefault();
                if (resource.LocationType == "File")
                {
                    File.Copy(instance.LocalTempProcDirectory + fileName, resource.File.Path + fileName, true);
                }
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }
    }
}
