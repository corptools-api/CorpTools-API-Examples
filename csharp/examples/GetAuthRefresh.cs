using System;
namespace Examples.examples
{
    // Example of GET /auth/refresh
    
    public class GetAuthRefresh : BaseRequest
    {
        public GetAuthRefresh()
        {
		}

        public override string SendRequest()
        {
            return GetRequest("auth/refresh");
        }
    }
}