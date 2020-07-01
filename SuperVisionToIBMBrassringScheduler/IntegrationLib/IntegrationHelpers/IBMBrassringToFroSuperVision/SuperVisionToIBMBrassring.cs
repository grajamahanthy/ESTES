using IntegrationLib.Common;
using IntegrationLib.Common.Classes;
using IntegrationLib.VendorClasses.IBMBrassring;
using IntegrationLib.VendorClasses.SuperVision.MVR;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IntegrationLib.IntegrationHelpers.IBMBrassringToFroSuperVision
{
    public class SuperVisionToIBMBrassring : IntegrationBase
    {
        public string configPath = string.Empty;
        public SuperVisionToIBMBrassring(string _configPath) : base(_configPath)
        {
            configPath = _configPath;
        }

        public override async Task<string> RunAndReturn(string inputXmlStr = null) { return string.Empty; }
        public override async void Run(string inputXmlStr = null)
        {
            try
            {
                Func<string, Task<bool>> execIntegration = new Func<string, Task<bool>>(ExecIntegration);
                FtpHelper ftpHelper = FtpHelper.GetInstance(config);
                await FtpHelper.ProcessFtpData(execIntegration);
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }


        public async Task<bool> ExecIntegration(string sourceXml)
        {
            BrassringHelper bH = new BrassringHelper(configPath);
            try
            {
                //Serialize Source XML to Target Form Import Vendor XML.
                string targetBrassringFormXml = bH.ConvertSuperVisonMVRReportXmlToIBMBrassringFormImportXml(sourceXml);

                //FormImport to Brassring
                bH.BrassringFormImport(targetBrassringFormXml);

                //Serialize Source XML to Target Candidate Import Vendor XML.
                string targetBrassringCandidateXml = bH.ConvertSuperVisonMVRReportXmlToIBMBrassringCandImportXml(sourceXml); ;

                //Import PDF attachment to Candidates in Brassring
                if (!string.IsNullOrEmpty(targetBrassringCandidateXml))
                    bH.BrassringCandidateImport(targetBrassringCandidateXml);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public class BrassringHelper
    {
        public LoggerHelper logger;
        public Config config;
        public XmlDocument configXml;

        public BrassringHelper(string _configPath)
        {
            try
            {
                configXml = new XmlDocument();
                configXml.Load(_configPath);
                SerializationHelper sH = new SerializationHelper();
                config = sH.Deserialize<Config>(configXml.OuterXml);
                logger = LoggerHelper.GetInstance(config);
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public string ConvertSuperVisonMVRReportXmlToIBMBrassringFormImportXml(string sourceXml)
        {
            try
            {
                string IBMBrassringFormImportXmlString = string.Empty;
                SerializationHelper sH = new SerializationHelper();
                MVRReports mR = sH.Deserialize<MVRReports>(sourceXml);
                XmlNode formImportIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"FormImport\"]");
                bool isMVRResultsAvailable = IsMVRResultsAvailable(mR);
                bool IsMvrResultError = (mR.MVRReport.Error != null && !string.IsNullOrEmpty(mR.MVRReport.Error.Description));


                //Load Brassring FormImport Xml Config
                string formImportEnvelop = formImportIntegrationNode.SelectSingleNode("Request/RequestData/Envelope").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                string formImportPayload = formImportIntegrationNode.SelectSingleNode("Request/RequestData/PayLoad").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                form formObj = sH.Deserialize<form>(formImportPayload);



                //Mapping from MVR to FormImport XML Start-----------------------------
                formObj.FormInput.OfType<formFormInput>().ToList().Where(f => f.title.ToLower() == "first name")
                                 .Select(s => { s.Value = EscapeXml(mR.MVRReport.Driver.FirstName); return s; })
                                 .ToList();
                formObj.FormInput.OfType<formFormInput>().ToList().Where(f => f.title.ToLower() == "last name")
                                 .Select(s => { s.Value = EscapeXml(mR.MVRReport.Driver.LastName); return s; })
                                 .ToList();
                formObj.FormInput.OfType<formFormInput>().ToList().Where(f => f.title.ToLower() == "mvr results found?")
                                .Select(s => { s.Value = (isMVRResultsAvailable ? "Yes" : "No"); return s; })
                                .ToList();

                if (IsMvrResultError)
                {
                    formObj.FormInput.OfType<formFormInput>().ToList().Where(f => f.title.ToLower() == "status description")
                                .Select(s => { s.Value = (IsMvrResultError ? mR.MVRReport.Error.Description : string.Empty); return s; })
                                .ToList();
                }
                formObj.resumeKey = mR.MVRReport.Driver.DriverReferenceNumber;
                formObj.autoreq = mR.MVRReport.Quoteback;
                //Mapping from MVR to FormImport XML End-------------------------------




                //Map SuperVision data to Brassring Form Import Xml
                string formImportPayloadXml = sH.Serialize<form>(formObj);



                //Construct Complete FormImport Envelope+Payload Xml
                XmlDocument formImportXml = new XmlDocument();
                formImportXml.LoadXml(formImportEnvelop);
                XmlNode formImportPayLoad = formImportXml.SelectSingleNode("Envelope/Packet/Payload");
                formImportPayLoad.InnerXml = "<![CDATA[" + formImportPayloadXml + "]]>";



                logger.Log(LogType.Success, "MVR to Brassring Form Import XML Conversion: Success");
                return formImportXml.OuterXml.ToString();
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "MVR to Brassring Form Import XML Conversion: Error - " + ex.Message);
                throw new Exception("MVR to Brassring Form Import XML Conversion: Error - " + ex.Message);
            }
        }
        public string ConvertSuperVisonMVRReportXmlToIBMBrassringCandImportXml(string sourceXml)
        {
            try
            {
                string IBMBrassringCandImportXmlString = string.Empty;
                SerializationHelper sH = new SerializationHelper();
                MVRReports mR = sH.Deserialize<MVRReports>(sourceXml);
                bool isMVRResultsAvailable = IsMVRResultsAvailable(mR);

                if (isMVRResultsAvailable)
                {
                    XmlNode CandImportIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"CandidateImport\"]");

                    //Load Brassring CandImport Xml Config
                    string CandImportEnvelop = CandImportIntegrationNode.SelectSingleNode("Request/RequestData/Envelope").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    string CandImportPayload = CandImportIntegrationNode.SelectSingleNode("Request/RequestData/PayLoad").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    Candidate candObj = sH.Deserialize<Candidate>(CandImportPayload);

                    //Mapping from MVR to FormImport XML Start-----------------------------
                    candObj.CandidateProfile.PersonalData.PersonName.GivenName = EscapeXml(mR.MVRReport.Driver.FirstName);
                    if (!string.IsNullOrEmpty(Convert.ToString(mR.MVRReport.Driver.MiddleName)))
                        candObj.CandidateProfile.PersonalData.PersonName.MiddleName = EscapeXml(mR.MVRReport.Driver.MiddleName);
                    candObj.CandidateProfile.PersonalData.PersonName.FamilyName = EscapeXml(mR.MVRReport.Driver.LastName);
                    candObj.CandidateRecordInfo.Id.IdValue = mR.MVRReport.Driver.DriverReferenceNumber;

                    for (int i = 0; i < candObj.CandidateProfile.UserArea.codes.Length; i++)
                    {
                        if (candObj.CandidateProfile.UserArea.codes[i] == "[AutoReqId]")
                        {
                            candObj.CandidateProfile.UserArea.codes[i] = mR.MVRReport.Quoteback;
                        }
                    }
                    candObj.CandidateProfile.UserArea.attachments.attachment.documentguid = Guid.NewGuid().ToString();
                    candObj.CandidateProfile.UserArea.attachments.attachment.filename = EscapeXml($"MVRReport_{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss").Replace(" ", string.Empty).Replace("\\", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty)}");
                    candObj.CandidateProfile.UserArea.attachments.attachment.fileextn = mR.MVRReport.EmbeddedReports.EmbeddedReport.Type;
                    candObj.CandidateProfile.UserArea.attachments.attachment.file = mR.MVRReport.EmbeddedReports.EmbeddedReport.Data;
                    candObj.CandidateProfile.UserArea.attachments.attachment.reqs.reqcode = mR.MVRReport.Quoteback;
                    //formObj.autoreq = mR.MVRReport.Quoteback;
                    //Mapping from MVR to FormImport XML End-------------------------------


                    //Map SuperVision data to Brassring Form Import Xml
                    string CandImportPayloadXml = sH.Serialize<Candidate>(candObj);

                    //Construct Complete CandImport Envelope+Payload Xml
                    XmlDocument CandImportXml = new XmlDocument();
                    CandImportXml.LoadXml(CandImportEnvelop);

                    XmlNamespaceManager nMgr = new XmlNamespaceManager(CandImportXml.NameTable);
                    nMgr.AddNamespace("BRpartner", "http://trm.brassring.com/brpartner");
                    nMgr.AddNamespace("RHrxml", "http://ns.hr-xml.org/2004-08-02");
                    XmlNode CandImportPayLoad = CandImportXml.SelectSingleNode("BRpartner:Envelope/Packet/Payload", nMgr);
                    CandImportPayLoad.InnerXml = "<![CDATA[" + CandImportPayloadXml + "]]>";

                    logger.Log(LogType.Success, "MVR to Brassring Candidate Import XML Conversion: Success");
                    return CandImportXml.OuterXml.ToString();
                }
                else
                {
                    logger.Log(LogType.Error, "MVR Results is not available to do Brassring Candidate Import. Please find the below error in Driver's data.");
                    logger.Log(LogType.Error, "Error: " + mR.MVRReport.Error.Description);

                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "MVR to Brassring Candidate Import XML Conversion: Error - " + ex.Message);
                throw new Exception("MVR to Brassring Candidate Import XML Conversion: Error - " + ex.Message);
            }
        }
        public string BrassringFormImport(string targetBrassringFormXml)
        {
            try
            {
                XmlNode formImportIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"FormImport\"]");
                string postUrl = formImportIntegrationNode.SelectSingleNode("Request").Attributes["Url"].Value;
                HttpModel hM = new HttpModel();
                hM.Url = postUrl;
                hM.IsBasicAuthEnabled = false;
                hM.paramsData = targetBrassringFormXml;
                HttpWebResponse result = HttpHelper.Post(hM);
                var responseString = new StreamReader(result.GetResponseStream()).ReadToEnd();

                if (responseString.Contains("<LongDescription>FORM Data transfer was a success</LongDescription>"))
                {
                    logger.Log(LogType.Success, "Form import: successful.");
                    return "FORM Data transfer was a success.";
                }
                else
                {
                    logger.Log(LogType.Error, "Form import: Error - " + responseString);
                    throw new Exception("Form import: Error - " + responseString);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Form import: Error - " + ex.Message);
                throw new Exception("Form import: Error - " + ex.Message);
            }
        }
        public string BrassringCandidateImport(string targetBrassringCandidateXml)
        {
            try
            {
                XmlNode formImportIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"CandidateImport\"]");
                string postUrl = formImportIntegrationNode.SelectSingleNode("Request").Attributes["Url"].Value;
                HttpModel hM = new HttpModel();
                hM.Url = postUrl;
                hM.IsBasicAuthEnabled = false;
                hM.paramsData = targetBrassringCandidateXml;
                HttpWebResponse result = HttpHelper.Post(hM);
                var responseString = new StreamReader(result.GetResponseStream()).ReadToEnd();

                if (responseString.Contains("<LongDescription>IMPORT Data transfer was a success</LongDescription>"))
                {
                    logger.Log(LogType.Success, "Candidate import is successful.");
                    return "Candidate Import was a success.";
                }
                else
                {
                    logger.Log(LogType.Error, "Candidate import: Error - " + responseString);
                    throw new Exception("Candidate import: Error - " + responseString);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Candidate import: Error - " + ex.Message);
                throw new Exception("Candidate import: Error - " + ex.Message);
            }
        }

        public bool IsMVRResultsAvailable(MVRReports MvrReports)
        {
            try
            {
                return !((MvrReports.MVRReport.Error != null && !string.IsNullOrEmpty(MvrReports.MVRReport.Error.Description))
                        || MvrReports.MVRReport.EmbeddedReports == null
                        || MvrReports.MVRReport.EmbeddedReports.EmbeddedReport == null
                        || string.IsNullOrEmpty(MvrReports.MVRReport.EmbeddedReports.EmbeddedReport.Data));
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public string EscapeXml(string inputString)
        {
            try
            {
                inputString = inputString.Replace(">", "&gt;");
                inputString = inputString.Replace("<", "&lt;");
                inputString = inputString.Replace("'", "&apos;");
                inputString = inputString.Replace("\"", "&quot;");

                return inputString;
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }
    }


}
