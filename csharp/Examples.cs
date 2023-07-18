using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using dotenv;


namespace Examples
{   
    class Program
    {
        // Here we have examples of how to add a callback to the API, getting a list of all callbacks added, and an example
        // of what it would look like to listen for that callback to trigger and then how to decode the corresponding data
        static void Main(string[] args)
        {
            //AddCallback();
            GetCallbacks();
            //ListenForCallback();
        }

       
        private static void ListenForCallback()
        {
            dotenv.net.DotEnv.Load();
            string callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(callbackUrl);
            listener.Start();
            
            HttpListenerContext context   = listener.GetContext();
            HttpListenerRequest request   = context.Request;
            System.IO.StreamReader reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
            
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
            var token = new JwtSecurityTokenHandler().ReadJwtToken(data["data"]);

            foreach (KeyValuePair<string, object> entry in token.Payload)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value.ToString());
            }

            context.Response.Close();
            listener.Stop();
        }

        private static void AddCallback()
        {
            dotenv.net.DotEnv.Load();
            string callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                url = callbackUrl
            });

            Request request = new Request();
            request.PostRequest("callbacks", body);
        }

        private static void GetCallbacks()
        {
            Request request = new Request();
            request.GetRequest("callbacks", "");
        }
    }
}