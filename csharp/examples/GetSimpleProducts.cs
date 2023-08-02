using System;
namespace Examples.examples
{
    // Example of GET /simple-products

    public class GetSimpleProducts : BaseRequest
    {
        private string _websiteUrl;

        public GetSimpleProducts()
        {
            dotenv.net.DotEnv.Load();
            _websiteUrl = Environment.GetEnvironmentVariable("WEBSITE_URL");
            Console.WriteLine($"GetSimpleProducts: _websiteUrl={_websiteUrl}");
        }

        public override void SendRequest()
        {
            GetRequest($"simple-products?url={_websiteUrl}");
        }
    }
}

