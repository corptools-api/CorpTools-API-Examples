using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace Examples
{
    /*
     * Base Request class with examples of how to generate the JWT token and make generic HTTP requests 
     */
    public abstract class BaseRequest
    {
        protected static string _accessKey;
        protected static string _secretKey;
        protected static string _apiUrl;

        protected BaseRequest()
        {
            dotenv.net.DotEnv.Load();
            _accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY");
            _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY");
            _apiUrl = Environment.GetEnvironmentVariable("API_URL");
            Console.WriteLine($"BaseRequest: _apiUrl={_apiUrl} _accessKey={_accessKey} _secretKey={_secretKey}");
        }

        public abstract string SendRequest();

        protected string DeleteRequest(string path)
        {
            try {
                var client = new RestClient(_apiUrl);
                var request = new RestRequest(path, Method.Delete);
                request.RequestFormat = DataFormat.Json;
                GenerateJwtToken(ref request, path);
                var response = client.Delete(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            return "";
        }

        protected string GetRequest(string path)
        {
            try {
                var client = new RestClient(_apiUrl);
                var request = new RestRequest(path, Method.Get);
                request.RequestFormat = DataFormat.Json;
                GenerateJwtToken(ref request, path);
                var response = client.Get(request);
                string contentType = response.ContentType;
                return HandleResponse(response, path, contentType);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            return "";
        }

        protected string PatchRequest(string path, string body)
        {
            try {
                var client = new RestClient(_apiUrl);
                var request = new RestRequest(path, Method.Patch);
                request.RequestFormat = DataFormat.Json;
                GenerateJwtToken(ref request, path, body);
                var response = client.Patch(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            return "";
        }

        protected string PostRequest(string path, string body)
        {
            try
            {
                var client = new RestClient(_apiUrl);
                var request = new RestRequest(path, Method.Post);
                request.RequestFormat = DataFormat.Json;
                GenerateJwtToken(ref request, path, body);
                var response = client.Post(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            return "";
        }

        protected string HandleResponse(RestResponse response, string path, string contentType = "application/json")
        {
            if (contentType == "application/json")
            {
                Console.WriteLine(response.Content);
            }
            else if (contentType == "image/png")
            {
                string responseFileName = BuildResponseFileName(path);
                byte[] data = response.RawBytes;
                string filePath = Path.Combine("documents", $"{responseFileName}.png");
                File.WriteAllBytes(filePath, data);
                Console.WriteLine($"PNG file saved as {responseFileName}.png");
            }
            else if (contentType == "application/pdf")
            {
                string responseFileName = BuildResponseFileName(path);
                byte[] data = response.RawBytes;
                string filePath = Path.Combine("documents", $"{responseFileName}.pdf");
                File.WriteAllBytes(filePath, data);
                Console.WriteLine($"PDF file saved as {responseFileName}.pdf");
            }
            else
            {
                Console.WriteLine(response.Content);
            }

            return response.Content;
        }

        protected void GenerateJwtToken(ref RestRequest request, string path, string body = "")
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials)
            {
                { "access_key", _accessKey }
            };
            var payload = new JwtPayload
            {
                {"path", "/" + path},
                {"content", Sha256HexDigest(body) }
            };

            var securityToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityToken);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/json");
            if (body != "")
            {
                request.AddJsonBody(body);
            }
        }

        internal static string Sha256HexDigest(string body)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(body)))
                .Replace("-", String.Empty).ToLower();
        }

        internal static string BuildResponseFileName(string path)
        {
            return "get_" + path.Replace('/', '_') + "_response";
        }
    }
}