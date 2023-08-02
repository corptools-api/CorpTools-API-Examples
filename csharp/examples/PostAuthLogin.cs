using System;
using System.Diagnostics;

namespace Examples.examples
{
    // Example of POST /auth/login
    
    public class PostAuthLogin : BaseRequest
    {
        private string _email;
        private string _password;
        private string _website_id;

        public PostAuthLogin()
		{
            _email = Environment.GetEnvironmentVariable("EMAIL");
            _password = Environment.GetEnvironmentVariable("PASSWORD");
            _website_id = Environment.GetEnvironmentVariable("WEBSITE_ID");

            Console.WriteLine($"PostAuthLogin: _email={_email} _password={_password} _website_id={_website_id}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                email = _email,
                password = _password,
                website_id = _website_id
            });

            PostRequest("auth/login", body);
        }
    }
}