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
            var billing_address = new BillingAddress
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
}