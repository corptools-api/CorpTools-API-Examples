using System;
namespace Examples.examples
{
    // POST /callbacks
    public class PostCallbacks : BaseRequest
    {
        string _callbackUrl;

        public PostCallbacks()
		{
            _callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
            Console.WriteLine($"PostCallbacks: _callbackUrl={_callbackUrl}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                url = _callbackUrl
            });

            PostRequest("callbacks", body);
        }
    }
}