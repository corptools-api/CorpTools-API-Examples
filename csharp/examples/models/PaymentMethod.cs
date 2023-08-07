using System;
namespace Examples.examples
{
    public class PaymentMethod
    {
        public string number { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string cvc { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public BillingAddress billing_address { get; set; }
    }
}