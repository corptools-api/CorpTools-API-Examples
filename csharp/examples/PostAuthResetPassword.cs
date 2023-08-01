using System;

namespace Examples.examples
{
    // Example of POST /auth/reset-password
    public class PostAuthResetPassword : BaseRequest
    {
        private string _password;
        private string _token;
        
        public PostAuthResetPassword()
        {
            _token = Environment.GetEnvironmentVariable("RESET_PASSWORD_TOKEN");
            _password = Environment.GetEnvironmentVariable("PASSWORD");
           
            Console.WriteLine($"PostAuthResetPassword: _password={_password} _token={_token}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                token = _token,
                password = _password,
                password_confirmation = _password
            });

            PostRequest("auth/reset-password", body);
        }
    }
}