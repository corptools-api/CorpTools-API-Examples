using System;
namespace Examples.examples
{
    // GET /companies
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

