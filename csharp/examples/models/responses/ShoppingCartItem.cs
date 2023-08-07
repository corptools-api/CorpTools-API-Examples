using System;
namespace Examples.examples
{
	public class ShoppingCartItem
	{
		public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string company_id { get; set; }
        public string account_id { get; set; }
        public string product_id { get; set; }
        public string product_type { get; set; }
        public string product_option_id { get; set; }
        public double total { get; set; }
        public string title { get; set; }
        public string status { get; set; }
    }
}