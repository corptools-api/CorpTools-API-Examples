using System;
namespace Examples.examples
{
    // Example GET /shopping-cart
    
    public class GetShoppingCart : BaseRequest
	{
        private string _companyId;

        public GetShoppingCart()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"GetShoppingCart: _companyId={_companyId}");
        }

        public override void SendRequest()
        {
            GetRequest($"shopping-cart?company_ids={_companyId}");
        }
    }
}

