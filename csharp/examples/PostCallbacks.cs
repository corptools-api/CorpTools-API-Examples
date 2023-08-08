using System;
namespace Examples.examples
{
    // Example of POST /callbacks
    
    public class PostCallbacks : BaseRequest
    {
        private string _callbackUrl;

        public PostCallbacks()
		{
            _callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
            Console.WriteLine($"PostCallbacks: _callbackUrl={_callbackUrl}");
        }

        public override string SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                url = _callbackUrl
            });

            return PostRequest("callbacks", body);
        }
    }
}