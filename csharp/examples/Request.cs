using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using dotenv;

namespace Examples
{
    class Request
    {
        private static string _accessKey;
        private static string _secretKey;
        private static string _apiUrl;

        public Request() {
            dotenv.net.DotEnv.Load();
            _accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY");
            _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY");
            _apiUrl = Environment.GetEnvironmentVariable("API_URL");
        }

        public void GetRequest(string path, string queryParams)
        {
            var client = new RestClient(_apiUrl);
            var request = new RestRequest(path, Method.Get);
            request.RequestFormat = DataFormat.Json;
            GenerateJwtToken(ref request, path);
            var response = client.Get(request);
            Console.WriteLine(response.Content);
        }

        public void PostRequest(string path, string body)
        {
            var client = new RestClient(_apiUrl);
            var request = new RestRequest(path, Method.Post);
            request.RequestFormat = DataFormat.Json;
            GenerateJwtToken(ref request, path, body);
            var response = client.Post(request);
            Console.WriteLine(response.Content);
        }

        private void GenerateJwtToken(ref RestRequest request, string path, string body="")
        {
            var key         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header      = new JwtHeader(credentials)
            {
                { "access_key", _accessKey }
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