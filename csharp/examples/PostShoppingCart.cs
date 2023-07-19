using System;
namespace Examples.examples
{
    // POST /shopping-cart
    public class PostShoppingCart : BaseRequest
    {
        private string _companyId;
        private string _filingProductId;
        private string _filingMethodId;
        private int _quantity;
        // TODO: form_data parameter

        public PostShoppingCart()
		{
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _filingProductId = Environment.GetEnvironmentVariable("FILING_PRODUCT_ID");
            _filingMethodId = Environment.GetEnvironmentVariable("FILING_METHOD_ID");
            _quantity = 1;
            Console.WriteLine($"PostShoppingCart: _companyId={_companyId} _filingProductId={_filingProductId} _filingMethodId={_filingMethodId}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_id = _companyId,
                product_id = _filingProductId,
                product_option_id = _filingMethodId,
                quantity = _quantity
            });

            PostRequest("shopping-cart", body);
        }
    }
}