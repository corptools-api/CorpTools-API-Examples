using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Examples.examples;

namespace Examples
{   
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: setup a way to select which request to run
            // requestDeletePaymentMethods();
            // requestGetCallbacks();
            // requestGetCompany();
            // requestGetCompanies();
            // requestGetFilingMethods();
            // requestGetFilingProducts();
            // requestGetFilingProductsOfferings();
            // requestPostCallbacks();
            // requestPostCompanies();
            // requestPostPaymentMethods();
            // requestPostShoppingCart();
            // ListenForCallback();
        }

        private static void requestDeletePaymentMethods()
        {
            DeletePaymentMethods request = new DeletePaymentMethods();
            request.SendRequest();
        }

        private static void requestGetCallbacks()
        {
            GetCallbacks request = new GetCallbacks();
            request.SendRequest();
        }

        private static void requestGetCompanies()
        {
            GetCompanies request = new GetCompanies();
            request.SendRequest();
        }

        private static void requestGetCompany()
        {
            GetCompany request = new GetCompany();
            request.SendRequest();
        }

        private static void requestGetFilingMethods()
        {
            GetFilingMethods request = new GetFilingMethods();
            request.SendRequest();
        }

        private static void requestGetFilingProducts()
        {
            GetFilingProducts request = new GetFilingProducts();
            request.SendRequest();
        }

        private static void requestGetFilingProductsOfferings()
        {
            GetFilingProductsOfferings request = new GetFilingProductsOfferings();
            request.SendRequest();
        }

        private static void requestPostCallbacks()
        {
            PostCallbacks request = new PostCallbacks();
            request.SendRequest();
        }

        private static void requestPostCompanies()
        {
            PostCompanies request = new PostCompanies();
            request.SendRequest();
        }

        private static void requestPostPaymentMethods()
        {
            PostPaymentMethods request = new PostPaymentMethods();
            request.SendRequest();
        }

        private static void requestPostShoppingCart()
        {
            PostShoppingCart request = new PostShoppingCart();
            request.SendRequest();
        }

        /**
         * Example of listening for event from our API, sent to the Callback URL
         */
        private static void ListenForCallback()
        {
            dotenv.net.DotEnv.Load();
            string callbackUrl = Environment.GetEnvironmentVariable("CALLBACK_URL");
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(callbackUrl);
            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
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
    }
}