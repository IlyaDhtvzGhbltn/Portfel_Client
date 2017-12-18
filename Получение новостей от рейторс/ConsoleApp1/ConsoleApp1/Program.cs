using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;

namespace ReutersKnowledge.Samples
{

    public class ConsoleApplication
    {

        private const string USER = "trkd-demo-wm@thomsonreuters.com";
        private const string APPLICATION = "trkddemoappwm";
        private const string PASSWORD = "o3o4h91ac";
        private string _token;
        
        public static void Main()
        {
            var app = new ConsoleApplication();
            app.CreateToken();
            app.OnlineReports_GetHeadlines();

            object ff = new object();
            JsonConvert.SerializeObject(ff);
            
            Console.ReadKey();
        }

        public void OnlineReports_GetHeadlines()
        {

            // Create the request JSON (refer the REQUEST INSPECT tab)
            // In this example, a string form of the JSON is used
            var requestJson = @"{
  ""GetHeadlines_Request_2"": {
    ""Topic"": ""OLUSBUS""
  }
}"

            // Execute the request
            var url = "http://api.trkd.thomsonreuters.com/api/OnlineReports/OnlineReports.svc/REST/OnlineReports_1/GetHeadlines_2";
            var responseJson = ExecuteRequest(url, requestJson, _token, APPLICATION);

            // Parse the response as a dynamic object
            dynamic response = JObject.Parse(responseJson);

            // You can then access the properties of the response
            // response.GetHeadlines_Response_2

            Console.WriteLine();
            Console.ReadKey();
        }


        public void CreateToken()
        {
            // Create token request object
            dynamic request = new ExpandoObject();
            request.CreateServiceToken_Request_1 = new ExpandoObject();
            request.CreateServiceToken_Request_1.Username = USER;
            request.CreateServiceToken_Request_1.ApplicationID = APPLICATION;
            request.CreateServiceToken_Request_1.Password = PASSWORD;

            // Convert to string form of JSON
            var requestJson = JsonConvert.SerializeObject(request);

            // Execute the request
            var url = "https://api.trkd.thomsonreuters.com/api/TokenManagement/TokenManagement.svc/REST/Anonymous/TokenManagement_1/CreateServiceToken_1";
            var responseJson = ExecuteRequest(url, requestJson);

            // Retrieve the token value
            dynamic response = JObject.Parse(responseJson);
            var token = response.CreateServiceToken_Response_1.Token;
            var expiry = response.CreateServiceToken_Response_1.Expiration;

            _token = token;
        }

        private string ExecuteRequest(string url, string json, string token = null, string appId = "trkddemoappwm")
        {

            // Create a HTTP web request with appropriate headers
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json; charset=utf-8";
            if (!string.IsNullOrEmpty(appId) && !string.IsNullOrEmpty(token))
            {
                webRequest.Headers.Add("X-Trkd-Auth-ApplicationID", appId);
                webRequest.Headers.Add("X-Trkd-Auth-Token", token);
            }

            byte[] request = Encoding.UTF8.GetBytes(json);
            using (var stream = webRequest.GetRequestStream())
                stream.Write(request, 0, request.Length);

            try
            {
                using (var resp = webRequest.GetResponse())
                {
                    using (var memStream = new MemoryStream())
                    using (var respStream = resp.GetResponseStream())
                    {
                        respStream.CopyTo(memStream);
                        return Encoding.UTF8.GetString(memStream.ToArray());
                    }
                }
            }
            catch (WebException excep)
            {
                if (excep.Response != null)
                {
                    using (var resp = excep.Response)
                    {
                        // Read the fault JSON
                        using (var memStream = new MemoryStream())
                        using (var respStream = resp.GetResponseStream())
                        {
                            respStream.CopyTo(memStream);
                            var faultJson = Encoding.UTF8.GetString(memStream.ToArray());
                            dynamic fault = JObject.Parse(faultJson);
                            throw new Exception(fault.Fault.Reason.Text.Value.ToString());
                        }
                    }
                }
                throw;
            }

        }

    }
}
