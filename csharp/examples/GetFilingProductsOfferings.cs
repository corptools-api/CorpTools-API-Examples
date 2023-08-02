using System;

namespace Examples.examples
{
    // Example of GET /filing-products/offerings
    
    class GetFilingProductsOfferings : BaseRequest
    {
		private string _companyId;
        private string _jurisdiction;

        public GetFilingProductsOfferings() : base()
		{
            dotenv.net.DotEnv.Load();
            _companyId      = Environment.GetEnvironmentVariable("COMPANY_ID");
            _jurisdiction   = Environment.GetEnvironmentVariable("JURISDICTION");
            Console.WriteLine($"GetFilingProductsOfferings: _companyId={_companyId} _jurisdiction={_jurisdiction}");
        }

        public override void SendRequest()
        {
            string path = "filing-products/offerings";
            string queryParams = $"?company_id={_companyId}&jurisdiction={_jurisdiction}";
            GetRequest(path + queryParams);
        }
	}
}