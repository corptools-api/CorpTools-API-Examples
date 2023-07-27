using System;
namespace Examples.examples
{
    // Example of GET /invoices
    // An array of company names or company_ids may be provided, but not both

    public class GetInvoices : BaseRequest
	{
        private string _companyId;

        public GetInvoices()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"GetInvoices: _companyId={_companyId}");
        }

        public override void SendRequest()
        {
            GetRequest($"invoices?company_ids={_companyId}");
        }
    }
}

