using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Examples.examples.models
{
    // Example of POST /services/:id/info
    public class PostServicesInfo : BaseRequest
    {
        private string _serviceId;
        private JObject _serviceInfo;

        public PostServicesInfo()
        {
            _serviceId = Environment.GetEnvironmentVariable("SERVICE_ID");
            loadInfo();
            Console.WriteLine($"PostServicesInfo: _serviceId={_serviceId} _serviceInfo={_serviceInfo}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(_serviceInfo);
            PostRequest($"services/{_serviceId}/info", body );
        }

        private void loadInfo()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string relativePath = "../data/services/add_info_corp.json";
            string filePath = Path.Combine(currentDirectory, relativePath);
            string jsonData = File.ReadAllText(filePath);
            _serviceInfo = JObject.Parse(jsonData);
        }
    }
}