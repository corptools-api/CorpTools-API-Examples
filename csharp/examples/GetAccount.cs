using System;
namespace Examples.examples
{
    // Example of GET /account
	public class GetAccount : BaseRequest
	{
		public GetAccount()
		{
		}

        public override void SendRequest()
        {
            GetRequest("account");
        }
    }
}