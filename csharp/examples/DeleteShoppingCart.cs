using System;
namespace Examples.examples
{
	// Example DELETE /shopping-cart
	public class DeleteShoppingCart : BaseRequest
	{
		private string _companyId;
		private string _shoppingCartItemId;

		public DeleteShoppingCart()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _shoppingCartItemId = Environment.GetEnvironmentVariable("SHOPPING_CART_ITEM_ID");
            Console.WriteLine($"GetFilingProductsOfferings: _companyId={_companyId} _shoppingCartItemId={_shoppingCartItemId}");
        }

		public override void SendRequest()
		{
            var company_ids = new string[] { _companyId };
            var item_ids = new string[] { _shoppingCartItemId };

            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_ids = company_ids,
                item_ids = item_ids
            });

            DeleteRequest("shopping-cart", body);
        }
    }
}

