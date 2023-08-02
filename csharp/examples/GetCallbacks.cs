using System;
namespace Examples.examples
{
    // Example of GET /callbacks
    
    public class GetCallbacks : BaseRequest
    {
        public GetCallbacks()
        {
        }

        public override void SendRequest()
        {
            GetRequest("callbacks");
        }
    }
}

