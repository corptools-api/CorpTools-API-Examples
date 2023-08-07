using System;
namespace Examples.examples
{
    // Example of GET /callbacks
    
    public class GetCallbacks : BaseRequest
    {
        public GetCallbacks()
        {
        }

        public override string SendRequest()
        {
            return GetRequest("callbacks");
        }
    }
}

