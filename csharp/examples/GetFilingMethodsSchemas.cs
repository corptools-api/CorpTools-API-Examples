using System;

namespace Examples.examples
{
    // Example of GET /filing-methods/schemas
    
    class GetFilingMethodsSchemas : BaseRequest
    {
        private string _companyId;
        private string _methodId;

        public GetFilingMethodsSchemas()
        {
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _methodId = Environment.GetEnvironmentVariable("FILING_METHOD_ID");
            Console.WriteLine($"GetFilingMethodsSchemas: company_id={_companyId} filing_method_id={_methodId}");
        }

        public GetFilingMethodsSchemas(string companyId, string filingMethodId)
        {
            _companyId = companyId;
            _methodId = filingMethodId;
        }

        public override string SendRequest()
        {
            string path = "filing-methods/schemas";
            string queryParams = $"?company_id={_companyId}&filing_method_id={_methodId}";
            return GetRequest(path + queryParams);
        }
    }
}
