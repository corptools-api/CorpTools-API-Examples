using System;

namespace Examples.examples
{
    // GET /filing-methods/schemas
    
    class GetFilingMethodsSchemas : BaseRequest
    {
        private string _companyId;
        private string _methodId;

        public GetFilingMethodsSchemas() : base()
        {
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _methodId = Environment.GetEnvironmentVariable("FILING_METHOD_ID");
            Console.WriteLine($"GetFilingMethodsSchemas: company_id={_companyId} filing_method_id={_methodId}");
        }

        public override void SendRequest()
        {
            string path = "filing-methods/schemas";
            string queryParams = $"?company_id={_companyId}&filing_method_id={_methodId}";
            GetRequest(path + queryParams);
        }
    }
}
