using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using IntegrationLib.Common;
using IntegrationLib.IntegrationHelpers;
using IntegrationLib.IntegrationHelpers.IBMBrassringToFroSuperVision;
using Newtonsoft.Json;
using SuperVisionAPI.Models;

namespace SuperVisionAPI.Controllers
{
    public class DriverController : ApiController
    {
        // POST api/<controller>
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            string inputCandExportXml = string.Empty;
            try
            {
                string BrassringCandidateExportPayloadXmlStr = string.Empty;
                inputCandExportXml = request.Content.ReadAsStringAsync().Result;
                DebuggerHelper.WriteToDebugFile(inputCandExportXml);
                BrassringCandidateExportPayloadXmlStr = GetBrassringCandidateExportPayload(inputCandExportXml);

                Integration integrationObj = new Integration();
                string outputXmlStr = integrationObj.intBase.RunAndReturn(BrassringCandidateExportPayloadXmlStr).Result;

                string responseXml = GetResponseXml(inputCandExportXml, outputXmlStr, true);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(responseXml, Encoding.UTF8, "application/xml")
                };
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                string responseXml = GetResponseXml(inputCandExportXml, ex.Message, false);
                return new HttpResponseMessage(){Content = new StringContent(responseXml, Encoding.UTF8, "application/xml")};
            }            
        }

        public static string GetBrassringCandidateExportPayload(string inputCandExportXml)
        {
            try{
                string cdataContent = string.Empty;
                //string[] inputCandExportXmlArr = inputCandExportXml.Split(new[] { "HRXMLDOC=" }, StringSplitOptions.None);
                //inputCandExportXml = inputCandExportXmlArr[1];
                XDocument XTemp = XDocument.Parse(inputCandExportXml);
                var cdataElement = (XCData)(XTemp.Descendants().Select(N => N.Element("Packet"))
                                    .Where(A => A.Element("PacketInfo")
                                    .Element("Manifest").Value == "SUPERVISION_CANDIDATE").FirstOrDefault()
                                    .Element("Payload").FirstNode);

                if (cdataElement != null)
                    cdataContent = cdataElement.Value;

                return cdataContent;
            }
            catch(Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public static string GetResponseXml(string inputCandExportXml, string outPutXmlStr, bool IsIntegrationSuccess)
        {
            try
            {
                string cdataContent = string.Empty;
                //string[] inputCandExportXmlArr = inputCandExportXml.Split(new[] { "HRXMLDOC=" }, StringSplitOptions.None);
                //inputCandExportXml = inputCandExportXmlArr[1];
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(inputCandExportXml);

                XmlNodeList SenderIds = doc.SelectNodes("/Envelope/Sender/Id");
                string SenderId = ((SenderIds != null && SenderIds.Count > 0) ? SenderIds[0].InnerText : "");
                XmlNodeList SenderCredentials = doc.SelectNodes("/Envelope/Sender/Credential");
                string SenderCredential = ((SenderIds != null && SenderIds.Count > 0) ? SenderCredentials[0].InnerText : "");



                SuperVisionAPI.Models.Envelope rM = new SuperVisionAPI.Models.Envelope();
                rM.Sender = new EnvelopeSender { Id = SenderId,
                                                 Credential = SenderCredential
                                               };
                rM.Packet = new EnvelopePacket { PacketInfo = new EnvelopePacketPacketInfo
                                                 {
                                                    packetType = "response",
                                                    PacketId = 1,
                                                    Action = "SET",
                                                    Manifest = "SUPERVISION_CANDIDATE"
                                                 }
                                               };

                rM.TransactInfo = new EnvelopeTransactInfo
                {
                    transactType = "response",
                    TimeStamp = Convert.ToString(DateTime.Now)
                };

                MVRResponseModel MVRResponse = JsonConvert.DeserializeObject<MVRResponseModel>(outPutXmlStr);
                if (IsIntegrationSuccess && (MVRResponse.ResponseErrors == null || MVRResponse.ResponseErrors.Length == 0))
                {
                    rM.Packet.PacketInfo.Status = new EnvelopePacketPacketInfoStatus
                    {
                        Code = 200,
                        ShortDescription = "SuperVision integration is successful.",
                        LongDescription = "SuperVision integration is successful."
                    };
                    rM.TransactInfo.Status = new EnvelopeTransactInfoStatus
                    {
                        Code = 200,
                        ShortDescription = "SuperVision integration is successful.",
                        LongDescription = "SuperVision integration is successful."
                    };
                }
                else
                {
                    string errorString = string.Empty;
                    foreach (Responseerror error in MVRResponse.ResponseErrors)
                    {
                        errorString = (errorString == string.Empty ? string.Empty : errorString + ", ");
                        errorString = errorString + error.ErrorDescription;
                    }

                    rM.Packet.PacketInfo.Status = new EnvelopePacketPacketInfoStatus
                    {
                        Code = 405,
                        ShortDescription = "SuperVision integration is failed.",
                        LongDescription = "SuperVision integration is failed with following validation messages. - " + errorString
                    };
                    rM.TransactInfo.Status = new EnvelopeTransactInfoStatus
                    {
                        Code = 405,
                        ShortDescription = "SuperVision integration is failed.",
                        LongDescription = "SuperVision integration is failed with following validation messages. - " + errorString
                    };
                }

                SerializationHelper sH = new SerializationHelper();
                string responseXml = sH.Serialize<SuperVisionAPI.Models.Envelope>(rM);
                return responseXml;
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public static string EscapeXml(string inputString)
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

    public class Integration
    {
        public IntegrationBase intBase { get; set; }
        public Integration()
        {
            string custFolder = ConfigurationManager.AppSettings["IntegrationFiles"].ToString();
            string configPath = custFolder + @"Config\Config.xml";
            this.intBase = new IBMBrassringToSuperVision(configPath);
        }
    }
}