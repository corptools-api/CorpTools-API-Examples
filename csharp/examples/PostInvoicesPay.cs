using System;
namespace Examples.examples
{
    // Example of POST /invoices/pay
    
    public class PostInvoicesPay : BaseRequest
    {
        private string _paymentToken;
        private string[] _invoiceIds;

        public PostInvoicesPay()
		{
            _paymentToken = Environment.GetEnvironmentVariable("PAYMENT_METHOD_ID");
            _invoiceIds = Environment.GetEnvironmentVariable("INVOICE_ID")?.Split(',');
            Console.WriteLine($"PostInvoicesPay: _paymentToken={_paymentToken} _invoiceIds={_invoiceIds}");
        }

        public override string SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                payment_token = _paymentToken,
                invoice_ids = _invoiceIds,
            });

            return PostRequest("invoices/pay", body);
        }
    }
}
