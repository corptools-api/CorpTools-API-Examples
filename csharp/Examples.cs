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

            // requestDeleteCallbacks();
            // requestDeletePaymentMethods();
            // requestDeleteShoppingCart();
            // requestGetAccount();
            // requestGetCallbacks();
            // requestGetCompany();
            // requestGetCompanies();
            // requestGetComplianceEvents();
            // requestGetDocuments();
            // requestGetFilingMethods();
            // requestGetFilingMethodsSchemas();
            // requestGetFilingProducts();
            // requestGetFilingProductsOfferings();
            // requestGetInvoice();
            // requestGetInvoices();
            // requestGetOrderItemsRequiringAttention();
            // requestGetPaymentMethods();
            // requestGetShoppingCart();
            // requestPostOrderItemsRequiringAttention();
            // requestPatchPaymentMethods();
            // requestPostCallbacks();
            // requestPatchCompanies();
            // requestPostCompanies();
            // requestPostInvoicesPay();
            // requestPostPaymentMethods();
            // requestPostShoppingCart();
            // requestPostShoppingCartCheckout();

            // ListenForCallback();
        }

        private static void requestDeleteCallbacks()
        {
            DeleteCallbacks request = new DeleteCallbacks();
            request.SendRequest();
        }

        private static void requestDeleteShoppingCart()
        {
            DeleteShoppingCart request = new DeleteShoppingCart();
            request.SendRequest();
        }

        private static void requestDeletePaymentMethods()
        {
            DeletePaymentMethods request = new DeletePaymentMethods();
            request.SendRequest();
        }

        private static void requestGetAccount()
        {
            GetAccount request = new GetAccount();
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

        private static void requestGetComplianceEvents()
        {
             GetComplianceEvents request = new GetComplianceEvents();
             request.SendRequest();
        }

        private static void requestGetDocuments()
        {
            GetDocuments request = new GetDocuments();
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

        private static void requestGetFilingMethodsSchemas()
        {
            GetFilingMethodsSchemas request = new GetFilingMethodsSchemas();
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

        private static void requestGetInvoice()
        {
            GetInvoice request = new GetInvoice();
            request.SendRequest();
        }

        private static void requestGetInvoices()
        {
            GetInvoices request = new GetInvoices();
            request.SendRequest();
        }

        private static void requestGetOrderItemsRequiringAttention()
        {
            GetOrderItemsRequiringAttention request = new GetOrderItemsRequiringAttention();
            request.SendRequest();
        }

        private static void requestGetPaymentMethods()
        {
            GetPaymentMethods request = new GetPaymentMethods();
            request.SendRequest();
        }

        private static void requestGetShoppingCart()
        {
            GetShoppingCart request = new GetShoppingCart();
            request.SendRequest();
        }

        private static void requestPatchPaymentMethods()
        {
            PatchPaymentMethods request = new PatchPaymentMethods();
            request.SendRequest();
        }

        private static void requestPostCallbacks()
        {
            PostCallbacks request = new PostCallbacks();
            request.SendRequest();
        }

        private static void requestPatchCompanies()
        {
            PatchCompanies request = new PatchCompanies();
            request.SendRequest();
        }

        private static void requestPostCompanies()
        {
            PostCompanies request = new PostCompanies();
            request.SendRequest();
        }

        private static void requestPostInvoicesPay()
        {
            PostInvoicesPay request = new PostInvoicesPay();
            request.SendRequest();
        }

        private static void requestPostOrderItemsRequiringAttention()
        {
            PostOrderItemsRequiringAttention request = new PostOrderItemsRequiringAttention();
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

        private static void requestPostShoppingCartCheckout()
        {
            PostShoppingCartCheckout request = new PostShoppingCartCheckout();
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
