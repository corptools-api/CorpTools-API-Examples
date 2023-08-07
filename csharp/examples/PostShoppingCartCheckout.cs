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
            _itemId = Environment.GetEnvironmentVariable("SHOPPING_CART_ITEM_ID");
            _paymentMethodId = Environment.GetEnvironmentVariable("PAYMENT_METHOD_ID");
            Console.WriteLine($"PostShoppingCartCheckout: _companyId={_companyId} _itemId={_itemId} _paymentMethodId={_paymentMethodId}");
        }

        public PostShoppingCartCheckout(string companyId, string shoppingCartItemId, string paymentMethodId)
        {
            _companyId = companyId;
            _itemId = shoppingCartItemId;
            _paymentMethodId = paymentMethodId;
            Console.WriteLine($"PostShoppingCartCheckout: _companyId={_companyId} _itemId={_itemId} _paymentMethodId={_paymentMethodId}");
        }

        public override string SendRequest()
        {
            string[] item_ids = { _itemId };
            string[] company_ids = { _companyId };

            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_ids = company_ids,
                item_ids = item_ids,
                payment_token = _paymentMethodId
            });

            return PostRequest("shopping-cart/checkout", body);
        }
    }
}

