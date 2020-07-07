using IntegrationLib.Common.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.Common
{
    public class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<HttpResponseMessage> Get(HttpModel httpObj)
        {
            try
            {
                if (httpObj.IsBasicAuthEnabled)
                {
                    var authToken = Encoding.ASCII.GetBytes($"{httpObj.UserName}:{httpObj.Password}");
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                }

                using (var result = await _httpClient.GetAsync($"{httpObj.Url}{httpObj.paramsData}"))
                {
                    if (result.StatusCode != HttpStatusCode.OK)
                    {
                        string resultResponse = await result.Content.ReadAsStringAsync();
                        DebuggerHelper.WriteExceptionToDebugFile(resultResponse);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }
        }

        public static HttpWebResponse Post(HttpModel httpObj, string requestContentType = null)
        {
            try
            {
                //if (httpObj.IsBasicAuthEnabled)
                //{
                //    var authToken = Encoding.ASCII.GetBytes($"{httpObj.UserName}:{httpObj.Password}");
                //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                //}
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                var request = (HttpWebRequest)WebRequest.Create(httpObj.Url);
                var data = Encoding.ASCII.GetBytes(httpObj.paramsData);
                request.Method = "POST";
                request.ContentType = "text/plain";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response;
                }
                else
                {
                    DebuggerHelper.WriteExceptionToDebugFile("(Error status code: " + response.StatusCode + ") - " + response.StatusDescription);
                    throw new Exception("(Error status code: " + response.StatusCode + ") - " + response.StatusDescription);
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
