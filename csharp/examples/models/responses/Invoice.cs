using System;
using System.Collections.Generic;

namespace Examples.examples
{
    public class Invoice
	{
        public class InvoiceItem
        {
            public double price { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
        }

        public string id { get; set; }
        public string status { get; set; }
        public string company_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string company { get; set; }
        public string due_date { get; set; }
        public List<InvoiceItem> items { get; set; }
    }
}