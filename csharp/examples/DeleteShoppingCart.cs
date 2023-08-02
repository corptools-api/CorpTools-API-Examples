using System;
namespace Examples.examples
{
	// Example of DELETE /shopping-cart

	public class DeleteShoppingCart : BaseRequest
	{
		private string _companyId;
		private string _shoppingCartItemId;

		public DeleteShoppingCart()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _shoppingCartItemId = Environment.GetEnvironmentVariable("SHOPPING_CART_ITEM_ID");
            Console.WriteLine($"DeleteShoppingCart: _companyId={_companyId} _shoppingCartItemId={_shoppingCartItemId}");
        }

		public override void SendRequest()
		{
            DeleteRequest($"shopping-cart?company_ids[]={_companyId}&item_ids[]={_shoppingCartItemId}");
        }
    }
}

