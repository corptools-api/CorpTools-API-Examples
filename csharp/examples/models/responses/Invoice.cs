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


//"id": "05d42782-3e02-4c73-9ef0-75178a8a67e4",
//    "invoice_number": "W27E3HBF",
//    "status": "unpaid",
//    "company_id": "ca78108b-c0c1-4036-8c8b-8ebe6c59f39a",
//    "created_at": "2023-08-07T11:59:58.000-07:00",
//    "updated_at": "2023-08-07T11:59:58.000-07:00",
//    "company": "Test Company 1",
//    "due_date": "2023-08-07T11:59:58.000-07:00",
//    "items": [
//      {
//        "price": 50.0,
//        "description": "Standard Federal EIN - Tax Id filing",
//        "quantity": 1
//      }
//    ]