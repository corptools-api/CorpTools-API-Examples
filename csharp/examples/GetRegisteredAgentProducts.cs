using System;
namespace Examples.examples
{
    // Example of GET /registered-agent-products

    public class GetRegisteredAgentProducts : BaseRequest
    {
        private string _websiteUrl;

		public GetRegisteredAgentProducts()
		{
            _websiteUrl = Environment.GetEnvironmentVariable("WEBSITE_URL");
            Console.WriteLine($"GetRegisteredAgentProducts: _websiteUrl={_websiteUrl}");
        }

        public override void SendRequest()
        {
            GetRequest($"registered-agent-products?url={_websiteUrl}");
        }
    }
}

