using System;

namespace Examples.examples
{
    // GET /companies/company_id
    class GetCompany : BaseRequest
    {
        private string _companyId;

        public GetCompany() : base()
        {
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"GetCompany: company_id={_companyId}");
        }

        public override void SendRequest()
        {
            string path = $"companies/{_companyId}";
            GetRequest(path);
        }
    }
}
