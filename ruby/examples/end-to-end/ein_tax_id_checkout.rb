require_relative '../../request.rb'

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

DEBUG = ENV['DEBUG']
COMPANY_ID	 = ENV['COMPANY_ID']
JURISDICTION = ENV['JURISDICTION']

begin 

	# Step 1: Get the 'EIN tax id' filing product id from GET /filing-products/offerings

	params = {
	  company_id: COMPANY_ID,
	  jurisdiction: JURISDICTION
	}
	response = BaseRequestRoute.request(:get, '/filing-products/offerings', query_params: params)
	product_id = response['result'].select { |product| product['filing_name'] == 'tax id' }.first['id']

	p "filing product id: #{product_id}" if DEBUG

	# Step 2: Get the filing method id from GET /filing-methods

	params = {
	  company_id: COMPANY_ID,
	  filing_product_id: product_id,
	  jurisdiction: JURISDICTION
	}

	response = BaseRequestRoute.request(:get, '/filing-methods', query_params: params)
	filing_method_id = response['result'].select { |method| method['name'] == 'Standard' && method['type'] == 'online' }.first['id']

	p "filing method id: #{filing_method_id}" if DEBUG

	# Step 3: Add the filing to cart with POST /shopping-cart

	# FORM_DATA = {} # optional, expects JSON mapping to fields of GET /filing-methods/schemas

	body = {
		company_id: COMPANY_ID,
		product_id: product_id,
		product_option_id: filing_method_id,
		quantity: 1,
		# form_data: FORM_DATA 
	}.to_json

	response = BaseRequestRoute.request(:post, '/shopping-cart', body: body)

	p "Add to cart: #{response['success']}" if DEBUG

	# Step 4: Add card information as payment method with POST /payment-methods

	body = { 
		number: '4000056655665556',
		exp_month: '05',
		exp_year: '2029',
		cvc: '888',
		first_name: 'Example',
		last_name: 'Test',
		billing_address: {
			"city": "New York",
			"state": "NY",
			"zip": "10463",
			"country": "US",
			"address1": "1234 Seasame Street",
			"address2": nil
		}
	}.to_json

	response = BaseRequestRoute.request(:post, '/payment-methods', body: body)

	p "Added payment method: #{response['success']}" if DEBUG

	# Step 5: Get payment method id from GET /payment-methods

	response = BaseRequestRoute.request(:get, '/payment-methods')
	payment_method_id = response['result']
		.select { |method|
		 	method['last4'] == '5556' && 
			method['exp_month'] == 5 &&
			method['exp_year'] == 2029 
		}.first['id']

	p "payment method id: #{payment_method_id}" if DEBUG

	# Step 6: Get shopping cart item id from GET /shopping-cart

	params = {
	  company_ids: [COMPANY_ID]
	}

	response = BaseRequestRoute.request(:get, '/shopping-cart', query_params: params)
	shopping_cart_item_id = response['result'].select { |item|
		item['product_id'] == product_id && 
		item['product_option_id'] == filing_method_id &&
		item['company_id'] == COMPANY_ID &&
		item['title'] == 'Tax id filing service - Standard'
	}.first['id']

	p "shopping cart item id: #{shopping_cart_item_id}" if DEBUG

	# Step 7: Perform shopping cart checkout

	parameters = {
	  'payment_token': payment_method_id,
	  # 'company_ids': [COMPANY_ID], # would include all items from the company's shopping cart
	  'item_ids': [shopping_cart_item_id]
	}.to_json

	response = BaseRequestRoute.request(:post, '/shopping-cart/checkout', body: parameters)
	invoice_id = response['invoice_ids'][0]

	p "shopping cart checkout: success=#{response['success']} invoice_id=#{invoice_id}" if DEBUG

	# Step 8: Check invoice status from GET /invoices/:invoice_id

	response = BaseRequestRoute.request(:get, "/invoices/#{invoice_id}")

	p "invoice status: #{response['result']['status']}" if DEBUG

	# Step 9: Get filing form schema from GET /filing-methods/schemas

	params = {
	  company_id: COMPANY_ID,
	  filing_method_id: filing_method_id
	}

	response = BaseRequestRoute.request(:get, '/filing-methods/schemas', query_params: params)

	p "form data schema: #{response['result']}" if DEBUG

	# Step 10: Get id of order item needing form data with GET /order-items/requiring-attention
	
	params = {
		company_ids: [COMPANY_ID]
	}

	response = BaseRequestRoute.request(:get, '/order-items/requiring-attention', query_params: params)
	order_item_id = response['result'].select { |item|
		item['name'] == 'Standard Federal EIN - Tax Id filing' &&
		item['company_id'] == COMPANY_ID
	}.first['id']

	p "order item requiring attention: #{order_item_id}" if DEBUG

	# Step 11: Add form_data to order item with POST /order-items/requiring-attention

	current_directory="#{File.dirname(File.expand_path(__FILE__))}"
	FORM_DATA = JSON.parse(File.read("#{current_directory}/../../../data/form_data_ein_tax_id.json"))
	
	p "form data: #{FORM_DATA}" if DEBUG

	params = {
	  'company_id': COMPANY_ID,
	  'form_data': FORM_DATA,
	  'order_item_id': order_item_id
	}.to_json

	response = BaseRequestRoute.request(:post, '/order-items/requiring-attention', body: params)

	# status should now be 'new', instead of 'requiring-client-attention'
	p "Added form data to order item: #{response['result']}" if DEBUG
 
 rescue StandardError => error
  abort("Something went wrong: #{error}")
end