using System;
namespace Examples.examples
{
    // Example of GET /services/:id/info
    public class GetServicesInfo : BaseRequest
    {
        private string _serviceId;

        public GetServicesInfo()
        {
            _serviceId = Environment.GetEnvironmentVariable("SERVICE_ID");
            Console.WriteLine($"GetServicesInfo: _serviceId={_serviceId}");
        }

        public override void SendRequest()
        {
            GetRequest($"services/{_serviceId}/info");
        }
    }
}