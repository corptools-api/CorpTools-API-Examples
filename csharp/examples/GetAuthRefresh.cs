using System;
namespace Examples.examples
{
    // Example of GET /auth/refresh
    
    public class GetAuthRefresh : BaseRequest
    {
        public GetAuthRefresh()
        {
		}

        public override void SendRequest()
        {
            GetRequest("auth/refresh");
        }
    }
}