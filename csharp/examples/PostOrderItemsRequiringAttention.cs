using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Examples.examples
{
    // Example of POST /order-items/requiring-attention
    public class PostOrderItemsRequiringAttention : BaseRequest
	{
        private static string _companyId;
        private static string _orderItemId;
        private static JObject _formData;

		public PostOrderItemsRequiringAttention()
		{
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _orderItemId = Environment.GetEnvironmentVariable("ORDER_ITEM_ID");
            loadFormData();
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_id = _companyId,
                order_item_id = _orderItemId,
                form_data = _formData
            });
            Console.WriteLine($"PostOrderItemsRequiringAttention: {body}");
            PostRequest("order-items/requiring-attention", body);
        }

        private void loadFormData()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string relativePath = "../data/form_data.json";
            string filePath = Path.Combine(currentDirectory, relativePath);
            string jsonData = File.ReadAllText(filePath);
            _formData = JObject.Parse(jsonData);
        }
    }
}