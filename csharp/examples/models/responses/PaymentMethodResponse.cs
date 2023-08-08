using System;
namespace Examples.examples
{
	public class PaymentMethodResponse
	{
		public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string last4 { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string created_at { get; set; }
        public string brand { get; set; }
        public Boolean is_prepaid { get; set; }
        public BillingAddress billing_address { get; set; }
    }
}