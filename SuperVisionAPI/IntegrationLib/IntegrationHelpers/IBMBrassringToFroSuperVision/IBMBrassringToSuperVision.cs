using IntegrationLib.Common;
using IntegrationLib.Common.Classes;
using IntegrationLib.VendorClasses.IBMBrassring;
using IntegrationLib.VendorClasses.SuperVision;
using Newtonsoft.Json;
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
    public class IBMBrassringToSuperVision : IntegrationBase
    {
        public string configPath = string.Empty;
        public IBMBrassringToSuperVision(string _configPath) : base(_configPath)
        {
            configPath = _configPath;
        }

        public override async void Run(string inputXmlStr = null) { }
        public override async Task<string> RunAndReturn(string inputXmlStr = null)
        {
            try
            {
                string outputXmlStr = await ExecIntegration(inputXmlStr);
                return outputXmlStr;
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Html, $"<p class=\"text-danger\">[{DateTime.Now}]: SuperVision order data is not processed successfully. {ex.Message}</p></body></html>", null, true);
                return string.Empty;
            }
        }


        public async Task<string> ExecIntegration(string sourceXml)
        {
            try
            {
                SuperVisionHelper bH = new SuperVisionHelper(configPath);
                string targetBrassringCandidateXml = bH.ConvertCandidateExportXmlToSuperVisionOrderRequestXml(sourceXml);
                string outputXmlStr = bH.SuperVisionOrderRequestImport(targetBrassringCandidateXml);

                if(outputXmlStr.ToLower().Contains("errorcode"))
                    logger.Log(LogType.Html, $"<p class=\"text-danger\">[{DateTime.Now}]: SuperVision order data is not processed successfully.</p></body></html>", null, true);
                else
                    logger.Log(LogType.Html, $"<p class=\"text-success\">[{DateTime.Now}]: SuperVision order data is processed successfully.</p></body></html>", null, true);

                return outputXmlStr;
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Html, $"<p class=\"text-danger\">[{DateTime.Now}]: SuperVision order data is not processed successfully.</p></body></html>", null, true);
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }
    }

    public class SuperVisionHelper
    {
        public LoggerHelper logger;
        public Config config;
        public XmlDocument configXml;

        public SuperVisionHelper(string _configPath)
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

        public string ConvertCandidateExportXmlToSuperVisionOrderRequestXml(string sourceXml)
        {
            try
            {
                string IBMBrassringCandImportXmlString = string.Empty;
                SerializationHelper sH = new SerializationHelper();
                SUPERVISION_CANDIDATE brassringCandExportXml = sH.Deserialize<SUPERVISION_CANDIDATE>(sourceXml);

                //Log FirstName, LastName, Resume Key
                string titleHtml = "<br/><br/>" + "<b>First Name: </b>" + brassringCandExportXml.LEGALFNAME + "<br/>";
                if (!string.IsNullOrEmpty(brassringCandExportXml.LEGALMNAME))
                    titleHtml = titleHtml + "<b>Middle Name: </b>" + brassringCandExportXml.LEGALMNAME + "<br/>";
                titleHtml = titleHtml + "<b>Last Name: </b>" + brassringCandExportXml.LEGALLNAME + "<br/>" + "<b>Resume key: </b>" + brassringCandExportXml.CANDIDATEID;

                logger.Log(LogType.Html, titleHtml);


                XmlNode SuperVisionOrderRequestIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"SuperVisionOrderRequest\"]");
                string SuperVisionOrderRequestIntegratioPayload = SuperVisionOrderRequestIntegrationNode.SelectSingleNode("Request/RequestData/PayLoad").InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                MVROrderRequest MVRReqInputObj = JsonConvert.DeserializeObject<MVROrderRequest>(SuperVisionOrderRequestIntegratioPayload);

                //Mapping from Brassring Candidate Xml to SuperVision Order Request xml.
                //----------------------------------------------------------------------
                Requestdriverdata rd = new Requestdriverdata();
                rd.driverReferenceNumber = Convert.ToString(brassringCandExportXml.CANDIDATEID);
                rd.licenseNumber = brassringCandExportXml.MVRDLNUMBER;


                //----------------Need confirmation Start----------------//
                if (!string.IsNullOrEmpty(brassringCandExportXml.MVRSUPSTATE))
                {
                    string[] mvrStateReportTypeString = brassringCandExportXml.MVRSUPSTATE.Split('_');

                    if (mvrStateReportTypeString.Length > 0)
                    {
                        rd.licenseState = mvrStateReportTypeString[0];

                        if (!string.IsNullOrEmpty(brassringCandExportXml.MVRREPORTTYPE)) {
                            rd.reportType = brassringCandExportXml.MVRREPORTTYPE;
                        }
                        else
                        {
                            rd.reportType = (mvrStateReportTypeString.Length > 1? mvrStateReportTypeString[1]:string.Empty);
                        }
                    }
                }
                
                if (!string.IsNullOrEmpty(Convert.ToString(brassringCandExportXml.MVRDOB)))
                    rd.birthDate = brassringCandExportXml.MVRDOB.ToString("yyyy-MM-dd");

                rd.cdlStatus = "Y";
                //----------------Need confirmation End----------------//


                rd.firstName = brassringCandExportXml.LEGALFNAME;
                rd.middleName = (string.IsNullOrEmpty(brassringCandExportXml.LEGALMNAME) ? string.Empty : brassringCandExportXml.LEGALMNAME);
                rd.lastName = brassringCandExportXml.LEGALLNAME;
                rd.quoteback = brassringCandExportXml.BRREQNUMBER;
                rd.allowMultipleMVROrdersPerDay = "Y";
                MVRReqInputObj.requestDetails.requestDriverData[0] = rd;
                //----------------------------------------------------------------------

                //Serializing SuperVision Order Request Object to Json string
                string MVRReqInputStr = JsonConvert.SerializeObject(MVRReqInputObj);

                logger.Log(LogType.Success, "Brassring Candidate Export XML to MVR Order request xml Conversion: Success");
                return Convert.ToString(MVRReqInputStr);
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Brassring Candidate Export XML to MVR Order request xml Conversion: Error - " + ex.Message);
                throw new Exception("Brassring Candidate Export XML to MVR Order request xml Conversion: Error - " + ex.Message);
            }
        }

        public string SuperVisionOrderRequestImport(string targetBrassringCandidateXml)
        {
            //------------------------START----------------------//
            XmlNode formImportIntegrationNode = configXml.SelectSingleNode("Config/Integrations/Integration[@Type=\"SuperVisionOrderRequest\"]");
            string postUrl = formImportIntegrationNode.SelectSingleNode("Request").Attributes["Url"].Value;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            string responseString;

            using (HttpClient vClient = new HttpClient())
            {
                try
                {
                    Uri vUri = new Uri(postUrl);
                    string vJsonObject = targetBrassringCandidateXml;
                    StringContent vStringContent = new StringContent(vJsonObject, Encoding.UTF8, "application/json");
                    HttpResponseMessage vHttpResponseMessage = vClient.PostAsync(vUri, vStringContent).Result;

                    if (vHttpResponseMessage == null)
                    {
                        throw new HttpRequestException($"Your error message here to relay a null response");
                    }

                    responseString = vHttpResponseMessage.Content.ReadAsStringAsync().Result;
                    if ((vHttpResponseMessage.StatusCode == HttpStatusCode.OK) || (vHttpResponseMessage.StatusCode == HttpStatusCode.BadRequest))
                    {
                        if(responseString.ToLower().Contains("errorcode"))
                            logger.Log(LogType.Error, "SuperVision API call has returned errors: <b>" + responseString + "</b>");
                        else
                            logger.Log(LogType.Success, "SuperVision API call is successful: <b>" + responseString + "</b>");

                    }
                    else
                    {
                        throw new HttpRequestException($"SuperVision API call is not successful: Your error message here to relay unexpected HttpStatus received");
                    }

                    return responseString;
                }
                catch (Exception e)
                {
                    logger.Log(LogType.Error, "SuperVision API call is not successful: Error - " + e.Message);
                    throw new Exception("SuperVision API call is not successful: Error - " + e.Message);
                }
            }
            //-------------------------END-----------------------//
        }
    }
}
