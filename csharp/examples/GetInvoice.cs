using System;

namespace Examples.examples
{
    // Example of GET /invoices/:invoice_id

    class GetInvoice : BaseRequest
    {
        private string _invoiceId;

        public GetInvoice()
        {
            dotenv.net.DotEnv.Load();
            _invoiceId = Environment.GetEnvironmentVariable("INVOICE_ID");
            Console.WriteLine($"GetInvoice: invoice_id={_invoiceId}");
        }

        public GetInvoice(string invoiceId)
        {
            _invoiceId = invoiceId;
        }

        public override string SendRequest()
        {
            string path = $"invoices/{_invoiceId}";
            return GetRequest(path);
        }
    }
}
