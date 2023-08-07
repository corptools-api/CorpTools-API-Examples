using System;

namespace Examples.examples
{
    // Example of GET /filing-methods
    
    class GetFilingMethods : BaseRequest
    {
        private string _companyId;
        private string _jurisdiction;
        private string _productId;

        public GetFilingMethods()
        {
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _jurisdiction = Environment.GetEnvironmentVariable("JURISDICTION");
            _productId = Environment.GetEnvironmentVariable("FILING_PRODUCT_ID");
            Console.WriteLine($"GetFilingMethods: company_id={_companyId} jurisdiction={_jurisdiction} filing_product_id={_productId}");
        }

        public GetFilingMethods(string companyId, string jursidiction, string productId)
        {
            _companyId = companyId;
            _jurisdiction = jursidiction;
            _productId = productId;
        }

        public override string SendRequest()
        {
            string path = "filing-methods";
            string queryParams = $"?company_id={_companyId}&jurisdiction={_jurisdiction}&filing_product_id={_productId}";
            return GetRequest(path + queryParams);
        }
    }
}
