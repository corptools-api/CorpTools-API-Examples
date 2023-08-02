using System;
namespace Examples.examples
{
	// Example of GET /payment-methods

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