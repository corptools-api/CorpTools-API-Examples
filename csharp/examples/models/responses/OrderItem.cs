using System;
namespace Examples.examples
{
	public class OrderItem
	{
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string company_id { get; set; }
        public string name { get; set; }
        public string order_id { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public OrderItemProduct product { get; set; }
    }

    public class OrderItemProduct
    {
        public string id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public FilingMethod filing_method { get; set; }
    }
}