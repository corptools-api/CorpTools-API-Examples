using System;
namespace Examples.examples
{
    // Example of DELETE /callbacks/:callback_id

    public class DeleteCallbacks : BaseRequest
    {
        private string _callbackId;

        public DeleteCallbacks()
        {
            dotenv.net.DotEnv.Load();
            _callbackId = Environment.GetEnvironmentVariable("CALLBACK_ID");
        
            Console.WriteLine($"DeleteCallbacks: _callbackId={_callbackId}");
        }

        public override void SendRequest()
        {
            DeleteRequest($"callbacks/{_callbackId}");
        }
    }
}

