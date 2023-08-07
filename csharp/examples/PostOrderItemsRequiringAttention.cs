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
            loadFormData("../data/form_data.json");
        }

        public PostOrderItemsRequiringAttention(string companyId, string orderItemId)
        {
            _companyId = companyId;
            _orderItemId = orderItemId;
            loadFormData("../data/form_data_ein_tax_id.json");
        }

        public override string SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_id = _companyId,
                order_item_id = _orderItemId,
                form_data = _formData
            });
            Console.WriteLine($"PostOrderItemsRequiringAttention: {body}");
            return PostRequest("order-items/requiring-attention", body);
        }

        private void loadFormData(string formDataFilePath)
        {
            string currentDirectory = Environment.CurrentDirectory;
            string relativePath = formDataFilePath;
            string filePath = Path.Combine(currentDirectory, relativePath);
            string jsonData = File.ReadAllText(filePath);
            _formData = JObject.Parse(jsonData);
        }
    }
}