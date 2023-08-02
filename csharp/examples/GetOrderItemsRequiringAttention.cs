using System;
namespace Examples.examples
{
    // Example of GET /order-items/requiring-attention
    
    public class GetOrderItemsRequiringAttention : BaseRequest
	{
        private string _companyId;

        public GetOrderItemsRequiringAttention()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"GetOrderItemsRequiringAttention: _companyId={_companyId}");
        }

        public override void SendRequest()
        {
            GetRequest($"order-items/requiring-attention?company_ids={_companyId}");
        }
    }
}

