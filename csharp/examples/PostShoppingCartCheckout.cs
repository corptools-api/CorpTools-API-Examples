using System;
namespace Examples.examples
{
    // Example of POST /shopping-cart/checkout
    
    public class PostShoppingCartCheckout : BaseRequest
	{
        private string _companyId;
        private string _paymentMethodId;
        private string _itemId;

        public PostShoppingCartCheckout()
		{
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _itemId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _paymentMethodId = Environment.GetEnvironmentVariable("COMPANY_ID");
            Console.WriteLine($"PostShoppingCartCheckout: _companyId={_companyId} _itemId={_itemId} _paymentMethodId={_paymentMethodId}");
        }

        public override void SendRequest()
        {
            string[] item_ids = { _itemId };
            string[] company_ids = { _companyId };

            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_ids = company_ids,
                item_ids = item_ids,
                payment_token = _paymentMethodId
            });

            PostRequest("shopping-cart/checkout", body);
        }
    }
}

