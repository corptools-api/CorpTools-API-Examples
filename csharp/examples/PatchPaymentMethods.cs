using System;
using Newtonsoft.Json;

namespace Examples.examples
{
    // Example PATCH /payment-methods/:payment_method_id

    public class PatchPaymentMethods : BaseRequest
    {
        private string _paymentMethodId;
        public PatchPaymentMethods()
        {
            dotenv.net.DotEnv.Load();
            _paymentMethodId = Environment.GetEnvironmentVariable("PAYMENT_METHOD_ID");
            Console.WriteLine($"PatchPaymentMethods: _paymentMethodId={_paymentMethodId}");
        }

        public override void SendRequest()
        {
            var billing_address = new BillingAddress
            {
                city = "New York",
                state = "NY",
                zip = "10463",
                country = "US",
                address1 = "20211 Seasame Street",
                address2 = ""
            };

            var payment_method = new PaymentMethod
            {
                number = "4000056655665556",
                exp_month = "03",
                exp_year = "2029",
                cvc = "543",
                first_name = "Elmo",
                last_name = "Grover",
                billing_address = billing_address
            };

            var body = JsonConvert.SerializeObject(payment_method, Formatting.None);

            PatchRequest($"payment-methods/{_paymentMethodId}", body);
        }
    }
}

