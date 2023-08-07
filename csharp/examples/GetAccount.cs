using System;
namespace Examples.examples
{
    // Example of GET /account

    public class GetAccount : BaseRequest
    {
        public GetAccount()
        {
            Console.WriteLine("GetAccount");
        }

        public override string SendRequest()
        {
            return GetRequest("account");
        }
    }
}