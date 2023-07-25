using System;

namespace Examples.examples
{
    // GET /invoices/:invoice_id
    class GetInvoice : BaseRequest
    {
        private string _invoiceId;

        public GetInvoice() : base()
        {
            dotenv.net.DotEnv.Load();
            _invoiceId = Environment.GetEnvironmentVariable("INVOICE_ID");
            Console.WriteLine($"GetInvoice: invoice_id={_invoiceId}");
        }

        public override void SendRequest()
        {
            string path = $"invoices/{_invoiceId}";
            GetRequest(path);
        }
    }
}
