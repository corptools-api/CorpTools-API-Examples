using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
namespace Examples.examples
{
    // Example of GET /invoices
    
    // An array of company names or company_ids may be provided, but not both

    public class GetInvoices : BaseRequest
	{
        private string _companyIds;

        public GetInvoices()
		{
            dotenv.net.DotEnv.Load();
            _companyIds = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"GetInvoices: _companyIds={_companyIds}");
        }

        public override string SendRequest()
         {
            // Construct the url with the ids param as an array in the query string
            var queryParams = new List<string>();
            foreach (var id in _companyIds.Split(','))
            {
                queryParams.Add($"company_ids[]={Uri.EscapeDataString(id)}");
            }
            var queryString = string.Join("&", queryParams);
            var urlWithParams = $"invoices?{queryString}";
            return GetRequest(urlWithParams);
         }
    }
}

