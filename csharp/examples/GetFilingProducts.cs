using System;

namespace Examples.examples
{
    // GET /filing-products
    class GetFilingProducts : BaseRequest
    {
		private string _websiteUrl;
        private string _jurisdiction;

        public GetFilingProducts() : base()
		{
            dotenv.net.DotEnv.Load();
            _websiteUrl     = Environment.GetEnvironmentVariable("WEBSITE_URL");
            _jurisdiction   = Environment.GetEnvironmentVariable("JURISDICTION");
            Console.WriteLine($"GetFilingProducts: _websiteUrl={_websiteUrl} _jurisdiction={_jurisdiction}");
        }

        public override void SendRequest()
        {
            string path = "filing-products";
            string queryParams = $"?url={_websiteUrl}&jurisdiction={_jurisdiction}";
            GetRequest(path + queryParams);
        }
	}
}