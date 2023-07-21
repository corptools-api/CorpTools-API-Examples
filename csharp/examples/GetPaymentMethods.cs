using System;
namespace Examples.examples
{
	// Example GET /payment-methods
	public class GetPaymentMethods : BaseRequest
	{
		public GetPaymentMethods()
		{
		}

        public override void SendRequest()
        {
			GetRequest("payment-methods");
        }
    }
}