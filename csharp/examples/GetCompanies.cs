using System;
namespace Examples.examples
{
    // Example of GET /companies
    
    public class GetCompanies : BaseRequest
    {
        public GetCompanies()
        {
        }

        public override void SendRequest()
        {
            GetRequest("companies");
        }
    }
}

