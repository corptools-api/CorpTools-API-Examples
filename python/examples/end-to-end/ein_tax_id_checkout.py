import pprint
import os
import sys
import json

sys.path.append(os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__)))))
sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

from get_filing_products_offerings import GetFilingProductsOfferingsRequest
from get_filing_methods import GetFilingMethodsRequest
from post_shopping_cart import PostShoppingCartRequest
from post_payment_methods import PostPaymentMethodsRequest
from get_payment_methods import GetPaymentMethodsRequest
from get_shopping_cart import GetShoppingCartRequest
from post_shopping_cart_checkout import PostShoppingCartCheckoutRequest
from get_invoice import GetInvoiceRequest
from get_filing_methods_schemas import GetFilingMethodsSchemasRequest
from get_order_items_requiring_attention import GetOrderItemsRequiringAttentionRequest
from post_order_items_requiring_attention import PostOrderItemsRequiringAttentionRequest

config = dotenv_values()

# Example of end-to-end 'EIN Tax Id' filing product shopping cart checkout
#
#     High-level steps:
#     1. Get the filing product id from GET /filing-products/offerings
#     2. Get the filing method id from GET /filing-methods
#     3. Add the filing to cart with POST /shopping-cart
#     4. Add card information as payment method with POST /payment-methods
#     5. Get payment method id from GET /payment-methods
#     6. Get shopping cart item id from GET /shopping-cart
#     7. Perform shopping cart checkout 
#     8. Check invoice status from GET /invoices/:invoice_id
#     # Optionally, skip these steps by providing 'form_data' parameter in step #3
#     9. Get filing form schema from GET /filing-methods/schemas
#     10. Get id of order item requiring client attention GET /order-items/requiring-attention
#     11. Add form_data to order item with POST /order-items

COMPANY_ID = config['COMPANY_ID']
JURISDICTION = config['JURISDICTION']

# Step 1: Get the filing product id from GET /filing-products/offerings

request = GetFilingProductsOfferingsRequest()
response = request.get_filing_products_offerings(COMPANY_ID, JURISDICTION)

filing_products = [product for product in response['result'] if product['filing_name'] == 'tax id']
product_id = filing_products[0]['id']

pprint.pprint(f'filing product id: {product_id}')

# Step 2: Get the filing method id from GET /filing-methods

request = GetFilingMethodsRequest()
response = request.get_filing_methods(COMPANY_ID, product_id, JURISDICTION)

filing_methods = [method for method in response['result'] if method['name'] == 'Standard' and method['type'] == 'online']
filing_method_id = filing_methods[0]['id']

pprint.pprint(f'filing method id: {filing_method_id}')

# Step 3: Add the filing to cart with POST /shopping-cart

request = PostShoppingCartRequest()
response = request.post_shopping_cart(COMPANY_ID, product_id, filing_method_id, 1)
success = response['success']

pprint.pprint(f'Add to cart: {success}')

# Step 4: Add card information as payment method with POST /payment-methods

payment_card_info = { 
		'number': '4000056655665556',
		'exp_month': '05',
		'exp_year': '2029',
		'cvc': '888',
		'first_name': 'Example',
		'last_name': 'Test',
		'billing_address': {
			"city": "New York",
			"state": "NY",
			"zip": "10463",
			"country": "US",
			"address1": "1234 Seasame Street",
			"address2": None
		}
	}
request = PostPaymentMethodsRequest()
response = request.post_payment_methods(payment_card_info)

pprint.pprint(f'Add payment method: {response}')

# Step 5: Get payment method id from GET /payment-methods

request = GetPaymentMethodsRequest()
response = request.get_payment_methods()

payment_methods = [method for method in response['result'] 
					if method['last4'] == '5556' and method['exp_month'] == 5 and method['exp_year'] == 2029 ]
payment_method_id = payment_methods[0]['id']

pprint.pprint(f'payment method id: {payment_method_id}')

# Step 6: Get shopping cart item id from GET /shopping-cart

request = GetShoppingCartRequest()
response = request.get_shopping_cart([COMPANY_ID])

shopping_cart_items = [item for item in response['result'] 
	if item['product_id'] == product_id and
	item['product_option_id'] == filing_method_id and
	item['company_id'] == COMPANY_ID and
	item['title'] == 'Tax id filing service - Standard'
]

shopping_cart_item_id = shopping_cart_items[0]['id']

pprint.pprint(f'shopping cart item id: {shopping_cart_item_id}')

# Step 7: Perform shopping cart checkout

request = PostShoppingCartCheckoutRequest()
response = request.post_checkout(COMPANY_ID, shopping_cart_item_id, payment_method_id)
checkout_invoice_id = response['invoice_ids'][0]

pprint.pprint(f'invoice id: {checkout_invoice_id}')

# Step 8: Check invoice status from GET /invoices/:invoice_id

request = GetInvoiceRequest()
response = request.get_invoice(checkout_invoice_id)
invoice_status = response['result']['status']

pprint.pprint(f'invoice status: {invoice_status}')

# Step 9: Get filing form schema from GET /filing-methods/schemas

request = GetFilingMethodsSchemasRequest()
response = request.get_filing_methods_schemas(COMPANY_ID, filing_method_id)

pprint.pprint(f'form data schema: {response}')

# Step 10: Get id of order item requiring client attention GET /order-items/requiring-attention

request = GetOrderItemsRequiringAttentionRequest()
response = request.get_requiring_attention([COMPANY_ID])
order_items = [item for item in response['result'] 
	if item['name'] == 'Standard Federal EIN - Tax Id filing' and
	item['company_id'] == COMPANY_ID
]
order_item_id = order_items[0]['id']

pprint.pprint(f'order item requiring attention: {order_item_id}')

# Step 11: Add form_data to order item with POST /order-items

cwd = os.getcwd();
file_path = f"{cwd}/../data/form_data_ein_tax_id.json";
with open(file_path, 'r') as file:
    form_data = json.load(file)
    pprint.pprint(f'form data: {form_data}')
    request = PostOrderItemsRequiringAttentionRequest()
    response = request.post_requring_attention(COMPANY_ID, order_item_id, form_data)
    pprint.pprint(f'Added form data to order item: {response}')

