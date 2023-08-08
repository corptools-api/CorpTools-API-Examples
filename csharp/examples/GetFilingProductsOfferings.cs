using System;

namespace Examples.examples
{
    // Example of GET /filing-products/offerings
    
    class GetFilingProductsOfferings : BaseRequest
    {
		private string _companyId;
        private string _jurisdiction;

        public GetFilingProductsOfferings()
		{
            dotenv.net.DotEnv.Load();
            _companyId      = Environment.GetEnvironmentVariable("COMPANY_ID");
            _jurisdiction   = Environment.GetEnvironmentVariable("JURISDICTION");
            Console.WriteLine($"GetFilingProductsOfferings: _companyId={_companyId} _jurisdiction={_jurisdiction}");
        }

        public GetFilingProductsOfferings(string companyId, string jursidiction)
        {
            _companyId = companyId;
            _jurisdiction = jursidiction;
        }

        public override string SendRequest()
        {
            string path = "filing-products/offerings";
            string queryParams = $"?company_id={_companyId}&jurisdiction={_jurisdiction}";
            return GetRequest(path + queryParams);
        }
	}
}