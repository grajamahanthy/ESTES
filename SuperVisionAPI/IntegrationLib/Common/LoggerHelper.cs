using IntegrationLib.Common.Classes;
using IntegrationLib.IntegrationHelpers;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.Common
{
    public class LoggerHelper : LoggerModel
    {
        //Our single instance of the singleton
        private static LoggerHelper instance = null;
        public static SmtpHelper sm = null;

        //Private constructor to deny instance creation of this class from outside
        private LoggerHelper()
        {
        }

        public static LoggerHelper GetInstance(Config config)
        {
            try
            {
                if (instance == null)
                {
                    sm = SmtpHelper.GetInstance(config);
                    instance = new LoggerHelper() { FtpConfig = new FtpModel() };
                    instance.FileName = $"Log_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}.html";//config.Resources.Logging.Ftp.FileName;
                    var LogResource = (from R in config.Resources where R.ResourceType == "Location" && R.Name == "Logging" select R).ToList().FirstOrDefault();
                    instance.LocationType = LogResource.LocationType;

                    if (instance.LocationType == "FTP")
                    {
                        instance.FtpConfig = new FtpModel()
                        {
                            Host = LogResource.Ftp.Host,
                            KeyFilePath = LogResource.Ftp.KeyFilePath,
                            LocalTempProcDirectory = LogResource.Ftp.LocalTempProcDirectory,
                            UserName = LogResource.Ftp.UserName,
                            Password = LogResource.Ftp.Password,
                            FtpFolderPath = LogResource.Ftp.FtpFolderPath
                        };
                    }
                    else
                    {
                        instance.FileConfig = new FileModel()
                        {
                            FilePath = LogResource.File.Path
                        };
                    }
                    LoadDefaultHtmlContentToLogFile();
                }
                return instance;
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public void Log(LogType logType, string message, string successErrorMsgDesc = null, bool isEndOfLog = false)
        {
            try
            {
                string filePath = string.Empty;
                string logText = string.Empty;

                if (instance.LocationType == "FTP")
                    filePath = Path.Combine(instance.FtpConfig.LocalTempProcDirectory, instance.FileName);
                else
                    filePath = Path.Combine(instance.FileConfig.FilePath, instance.FileName);

                if (logType == LogType.Html)
                {
                    logText = $"{message}";
                }
                else if (logType == LogType.Success)
                {
                    logText = $"<p class=\"text-success\">[{DateTime.Now}]: {message}</p>";
                }
                else if (logType == LogType.Error)
                {
                    logText = $"<p class=\"text-danger\">[{DateTime.Now}]: {message}</p>";
                }

                LogAsync(filePath, logText).GetAwaiter().GetResult();

                UploadLogFile();

                if (isEndOfLog)
                {
                    List<string> attachmentsForEmail = new List<string>();
                    attachmentsForEmail.Add(filePath);
                    sm.SendEmail(attachmentsForEmail);

                    if (instance.LocationType == "FTP")
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
            }
        }

        public async Task LogAsync(string filePath, string logText)
        {
            try
            {
                using (var streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(logText);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
                await LogAsync(filePath, logText);
            }
        }

        public static async Task StaticLogAsync(string filePath, string logText)
        {
            try
            {
                using (var streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(logText);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
                await StaticLogAsync(filePath, logText);
            }
        }

        public static async Task LoadDefaultHtmlContentToLogFile()
        {
            try
            {
                string filePath = string.Empty;
                string logText = string.Empty;

                if (instance.LocationType == "FTP")
                    filePath = Path.Combine(instance.FtpConfig.LocalTempProcDirectory, instance.FileName);
                else
                    filePath = Path.Combine(instance.FileConfig.FilePath, instance.FileName);

                logText = "<!doctype html>" +
                                            "<html lang=\"en\">" +
                                            "  <head>" +
                                            "    <meta charset=\"utf-8\">" +
                                            "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">" +
                                            "    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css\" integrity=\"sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh\" crossorigin=\"anonymous\">" +
                                            "    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js\" integrity=\"sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6\" crossorigin=\"anonymous\"></script>" +
                                            "    <title>Logging</title>" +
                                            "  </head>" +
                                            "  <body>";

                StaticLogAsync(filePath, logText).GetAwaiter().GetResult();

                UploadLogFile();
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
            }
        }

        public static void UploadLogFile()
        {
            try
            {
                if (instance.LocationType == "FTP")
                {
                    var methods = new List<AuthenticationMethod>();
                    methods.Add(new PasswordAuthenticationMethod(instance.FtpConfig.UserName, instance.FtpConfig.Password));

                    if (instance.FtpConfig.KeyFilePath != string.Empty)
                    {
                        PrivateKeyFile keyFile = new PrivateKeyFile(instance.FtpConfig.KeyFilePath);
                        var keyFiles = new[] { keyFile };
                        methods.Add(new PrivateKeyAuthenticationMethod(instance.FtpConfig.UserName, keyFiles));
                    }

                    ConnectionInfo con = new ConnectionInfo(instance.FtpConfig.Host, 22, instance.FtpConfig.UserName, methods.ToArray());
                    using (var sftp = new SftpClient(con))
                    {
                        sftp.Connect();
                        using (Stream localFile = File.Open(instance.FtpConfig.LocalTempProcDirectory + instance.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            sftp.UploadFile(localFile, instance.FtpConfig.FtpFolderPath + instance.FileName, true);
                        }
                    }
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
