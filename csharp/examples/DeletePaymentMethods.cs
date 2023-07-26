using System;
namespace Examples.examples
{
    // Example of DELETE /payment-methods/:id
	public class DeletePaymentMethods : BaseRequest
    {
        private string _paymentMethodId;

        public DeletePaymentMethods()
		{
            dotenv.net.DotEnv.Load();
            _paymentMethodId = Environment.GetEnvironmentVariable("PAYMENT_METHOD_ID");
            Console.WriteLine($"DeletePaymentMethods: _paymentMethodId={_paymentMethodId}");
        }

        public override void SendRequest()
        {
            DeleteRequest($"payment-methods/{_paymentMethodId}");
        }
    }
}

