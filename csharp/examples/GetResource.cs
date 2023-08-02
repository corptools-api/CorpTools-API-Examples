using System;
namespace Examples.examples
{
    // Example of GET /resources/:resource_id
    
    public class GetResource : BaseRequest
    {
        private string _resourceId;

        public GetResource()
        {
            _resourceId = Environment.GetEnvironmentVariable("AGENCY_RESOURCE_ID");
            Console.WriteLine($"GetResource: _resourceId={_resourceId}");
        }

        public override void SendRequest()
        {
            GetRequest($"resources/{_resourceId}");
        }
    }
}

