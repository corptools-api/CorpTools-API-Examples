using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace Examples
{
    class Program
    {
        private const string AccessKey   = "<access_key>";
        private const string SecretKey   = "<secret_key>";
        private const string ApiUrl      = "https://api.corporatetools.com";
        private const string CallbackUrl = "<callback_url>";
        
        // Here we have examples of how to add a callback to the API, getting a list of all callbacks added, and an example
        // of what it would look like to listen for that callback to trigger and then how to decode the corresponding data
        static void Main(string[] args)
        {
            // AddCallback();
            // GetCallbacks();
            ListenForCallback();
        }

        private static void ListenForCallback()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(CallbackUrl);
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
            var path    = "callbacks";
            var client  = new RestClient(ApiUrl);
            var request = new RestRequest(path, Method.POST, DataFormat.Json);
            
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                url = CallbackUrl
            });
            
            GenerateJwtToken(ref request, path, body);

            var response = client.Post(request);
                
            Console.WriteLine(response.Content);
            
        }

        private static void GetCallbacks()
        {
            var path    = "callbacks";
            var client  = new RestClient(ApiUrl);
            var request = new RestRequest(path, Method.GET, DataFormat.Json);
            
            GenerateJwtToken(ref request, path);

            var response = client.Get(request);
                
            Console.WriteLine(response.Content);
        }

        private static void GenerateJwtToken(ref RestRequest request, string path, string body="")
        {
            var key         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header      = new JwtHeader(credentials)
            {
                {"access_key", AccessKey}
            };
            var payload = new JwtPayload
            {
                {"path", "/" + path},
                {"content", Sha256HexDigest(body) }
            };
            
            var securityToken = new JwtSecurityToken(header, payload);
            var handler       = new JwtSecurityTokenHandler();
            var token   = handler.WriteToken(securityToken);
            
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            if (body != "")
            {
                request.AddJsonBody(body);
            }
        }

        private static string Sha256HexDigest(string body)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(body)))
                .Replace("-", String.Empty).ToLower();
        }
    }
}


