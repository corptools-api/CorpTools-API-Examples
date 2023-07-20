using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

namespace Examples.examples
{
    // Example POST /payment-methods
    public class PostPaymentMethods : BaseRequest
	{
		public PostPaymentMethods()
		{
		}

        public override void SendRequest()
        {
            var billing_address = new Address
            {
                city = "New York",
                state = "NY",
                zip = "10463",
                country = "US",
                address1 = "91011 Seasame Street",
                address2 = ""
            };

            var payment_method = new PaymentMethod
            {
                number = "4000056655665556",
                exp_month = "12",
                exp_year = "2028",
                cvc = "333",
                first_name = "Big",
                last_name = "Bird",
                billing_address = billing_address
            };

            var body = JsonConvert.SerializeObject(payment_method, Formatting.None);
            PostRequest("payment-methods", body);
        }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
    }

    public class PaymentMethod
    {
        public string number { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string cvc { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Address billing_address { get; set; }
    }
}

