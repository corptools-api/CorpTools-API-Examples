using System;

namespace Examples.examples
{
    // Example of POST /auth/forgot-password
    public class PostAuthForgotPassword : BaseRequest
	{
        private string _email;
        private string _subdomain;  // optional
        private string _website_id; // optional

        public PostAuthForgotPassword()
		{
            _email = Environment.GetEnvironmentVariable("EMAIL");
            _subdomain = Environment.GetEnvironmentVariable("SUBDOMAIN");
            _website_id = Environment.GetEnvironmentVariable("WEBSITE_ID");

            Console.WriteLine($"PostAuthForgotPassword: _email={_email} _subdomain={_subdomain} _website_id={_website_id}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                email_address = _email,
                // subdomain: _subdomain,
                website_id = _website_id
            });

            PostRequest("/auth/forgot-password", body);
        }
    }
}