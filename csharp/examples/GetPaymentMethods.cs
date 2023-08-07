using System;
namespace Examples.examples
{
	// Example of GET /payment-methods

	public class GetPaymentMethods : BaseRequest
	{
		public GetPaymentMethods()
		{
		}

        public override string SendRequest()
        {
			return GetRequest("payment-methods");
        }
    }
}