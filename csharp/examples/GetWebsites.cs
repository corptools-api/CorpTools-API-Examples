using System;
namespace Examples.examples
{
    // Example of GET /websites

    public class GetWebsites : BaseRequest
	{
        private string _websiteUrl;

        public GetWebsites()
		{
            dotenv.net.DotEnv.Load();
            _websiteUrl = Environment.GetEnvironmentVariable("WEBSITE_URL");
            Console.WriteLine($"GetWebsites: _websiteUrl={_websiteUrl}");
        }

        public override string SendRequest()
        {
            return GetRequest($"websites?url={_websiteUrl}");
        }
    }
}

