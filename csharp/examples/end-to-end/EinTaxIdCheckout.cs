using System;
using System.ComponentModel.Design;
using Newtonsoft.Json;

namespace Examples.examples
{
    // Example of end-to-end 'EIN Tax Id' filing product shopping cart checkout
    //
    //     High-level steps:
    //     1. Get the filing product id from GET /filing-products/offerings
    //     2. Get the filing method id from GET /filing-methods
    //     3. Add the filing to cart with POST /shopping-cart
    //     4. Add card information as payment method with POST /payment-methods
    //     5. Get payment method id from GET /payment-methods
    //     6. Get shopping cart item id from GET /shopping-cart
    //     7. Perform shopping cart checkout 
    //     8. Check invoice status from GET /invoices/:invoice_id
    //     # Optionally, skip these steps by providing 'form_data' parameter in step #3
    //     9. Get filing form schema from GET /filing-methods/schemas
    //     10. Get id of order item requiring client attention GET /order-items/requiring-attention
    //     11. Add form_data to order item with POST /order-items

    public class EinTaxIdCheckout
	{
        private string _companyId;
        private string _jurisdiction;

		public EinTaxIdCheckout()
		{
            dotenv.net.DotEnv.Load();
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _jurisdiction = Environment.GetEnvironmentVariable("JURISDICTION");
        }

		public void checkout()
		{
            // Step 1: Get the filing product id from GET /filing-products/offerings

            GetFilingProductsOfferings filing_products_request = new GetFilingProductsOfferings(_companyId, _jurisdiction);
            PublicApiResponse<FilingProduct> filing_products_response = JsonConvert.DeserializeObject<PublicApiResponse<FilingProduct>>(filing_products_request.SendRequest());

            string filingProductId = "";

            foreach (FilingProduct product in filing_products_response.result)
            {
                if (product.filing_name == "tax id")
                {
                    filingProductId = product.id;
                    break;
                }
            }

            Console.WriteLine("filing_product_id: " + filingProductId);

            // Step 2: Get the filing method id from GET /filing-methods

            GetFilingMethods getFilingMethodsRequest = new GetFilingMethods(_companyId, _jurisdiction, filingProductId);
            PublicApiResponse<FilingMethod> getFilingMethodsResponse = JsonConvert.DeserializeObject<PublicApiResponse<FilingMethod>>(getFilingMethodsRequest.SendRequest());

            string filingMethodId = "";

            foreach (FilingMethod method in getFilingMethodsResponse.result)
            {
                if (method.name == "Standard" && method.type == "online")
                {
                    filingMethodId = method.id;
                    break;
                }
            }

            Console.WriteLine("filingMethodId: " + filingMethodId);

            // Step 3: Add the filing to cart with POST /shopping-cart

            PostShoppingCart addToCartRequest = new PostShoppingCart(_companyId, filingProductId, filingMethodId, 1);
            PublicApiResponse<Object> addToCartResponse = JsonConvert.DeserializeObject<PublicApiResponse<Object>>(addToCartRequest.SendRequest());

            Console.WriteLine("add to cart success: " + addToCartResponse.success);

            // Step 4: Add card information as payment method with POST /payment-methods

            PostPaymentMethods addPaymentMethoRequest = new PostPaymentMethods();
            PublicApiResponse<Object> addPaymentMethoResponse = JsonConvert.DeserializeObject<PublicApiResponse<Object>>(addPaymentMethoRequest.SendRequest());

            Console.WriteLine($"add payment method: success={addPaymentMethoResponse.success}  status_code={addPaymentMethoResponse.status_code}");

            // Step 5: Get payment method id from GET /payment-methods

            GetPaymentMethods getPaymentMethodsRequest = new GetPaymentMethods();
            PublicApiResponse<PaymentMethodResponse> getPaymentMethodsResponse = JsonConvert.DeserializeObject<PublicApiResponse<PaymentMethodResponse>>(getPaymentMethodsRequest.SendRequest());

            string paymentMethodId = "";

            foreach (PaymentMethodResponse method in getPaymentMethodsResponse.result)
            {
                if (method.last4 == "5556" && method.exp_month == 12 && method.exp_year == 2028)
                {
                    paymentMethodId = method.id;
                    break;
                }
            }

            Console.WriteLine($"paymentMethodId: {paymentMethodId}");

            // Step 6: Get shopping cart item id from GET /shopping-cart

            GetShoppingCart getShoppingCartRequest = new GetShoppingCart(_companyId);
            PublicApiResponse<ShoppingCartItem> getShoppingCartResponse =
                JsonConvert.DeserializeObject<PublicApiResponse<ShoppingCartItem>>(getShoppingCartRequest.SendRequest());

            string shoppingCartItemId = "";

            foreach (ShoppingCartItem item in getShoppingCartResponse.result)
            {
                if (item.product_id == filingProductId &&
                    item.product_option_id == filingMethodId &&
                    item.company_id == _companyId &&
                    item.title == "Tax id filing service - Standard")
                {
                    shoppingCartItemId = item.id;
                    break;
                }
            }

            Console.WriteLine($"shoppingCartItemId: {shoppingCartItemId}");

            // Step 7: Perform shopping cart checkout

            PostShoppingCartCheckout postShoppingCartCheckoutRequest = new PostShoppingCartCheckout(_companyId, shoppingCartItemId, paymentMethodId);
            PublicApiResponse<Object> postShoppingCartCheckoutResponse =
                JsonConvert.DeserializeObject<PublicApiResponse<Object>>(postShoppingCartCheckoutRequest.SendRequest());

            string invoiceId = postShoppingCartCheckoutResponse.invoice_ids[0];

            Console.WriteLine($"invoiceId: {invoiceId}");

            // Step 8: Check invoice status from GET /invoices/:invoice_id

            GetInvoice getInvoiceRequest = new GetInvoice(invoiceId);
            PublicApiSingleResultResponse<Invoice> getInvoiceResponse =
                JsonConvert.DeserializeObject<PublicApiSingleResultResponse<Invoice>>(getInvoiceRequest.SendRequest());

            string invoiceStatus = getInvoiceResponse.result.status;

            Console.WriteLine($"invoiceStatus: {invoiceStatus}");

            // Step 9: Get filing form schema from GET /filing-methods/schemas

            GetFilingMethodsSchemas getFilingMethodsSchemasRequest = new GetFilingMethodsSchemas(_companyId, filingMethodId);
            PublicApiResponse<Object> getFilingMethodsSchemasResponse =
                JsonConvert.DeserializeObject<PublicApiResponse<Object>> (getFilingMethodsSchemasRequest.SendRequest());

            Console.WriteLine($"Schema: {JsonConvert.SerializeObject(getFilingMethodsSchemasResponse.result)}");

            // Step 10: Get id of order item requiring client attention GET /order-items/requiring-attention

            GetOrderItemsRequiringAttention getOrderItemsRequiringAttentionRequest = new GetOrderItemsRequiringAttention(_companyId);
            PublicApiResponse<OrderItem> getOrderItemsRequiringAttentionResponse =
                JsonConvert.DeserializeObject<PublicApiResponse<OrderItem>>(getOrderItemsRequiringAttentionRequest.SendRequest());

            string orderItemId = "";

            foreach (OrderItem item in getOrderItemsRequiringAttentionResponse.result)
            {
                if (item.name == "Standard Federal EIN - Tax Id filing" && item.company_id == _companyId)
                {
                    orderItemId = item.id;
                    break;
                }
            }

            Console.WriteLine($"orderItemId: {orderItemId}");

            // Step 11: Add form_data to order item with POST /order-items

            PostOrderItemsRequiringAttention postOrderItemsRequiringAttentionRequest = new PostOrderItemsRequiringAttention(_companyId, orderItemId);
            PublicApiSingleResultResponse<OrderItem> postOrderItemsRequiringAttentionResponse =
                JsonConvert.DeserializeObject<PublicApiSingleResultResponse<OrderItem>>(postOrderItemsRequiringAttentionRequest.SendRequest());

            Console.WriteLine($"post order item requiring attention: success={postOrderItemsRequiringAttentionResponse.success}");
        }
    }
}