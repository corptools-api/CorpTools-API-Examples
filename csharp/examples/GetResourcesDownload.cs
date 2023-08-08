using System;

namespace Examples.examples
{
    // Example of GET /resources/:resource_id/download

    // The specified resource is saved as a pdf in the 'documents' directory
    
    class GetResourcesDownload : BaseRequest
    {
        private string _resourceId;

        public GetResourcesDownload() : base()
        {
            dotenv.net.DotEnv.Load();
            _resourceId = Environment.GetEnvironmentVariable("AGENCY_RESOURCE_ID");
            Console.WriteLine($"GetResourcesDownload: resource_id={_resourceId}");
        }

        public override string SendRequest()
        {
            string path = $"resources/{_resourceId}/download";
            return GetRequest(path);
        }
    }
}
