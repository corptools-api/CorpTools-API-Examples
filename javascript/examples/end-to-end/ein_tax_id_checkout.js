const baseRequest = require('../../base_request.js').baseRequest
const fs = require('fs');
const path = require('path');
process.chdir(path.resolve(__dirname, '../../../'));
require('dotenv').config();

/**
 * Example of end-to-end 'EIN Tax Id' filing product shopping cart checkout
 * 
 * 		High-level steps:
 * 			1. Get the filing product id from GET /filing-products/offerings
 * 			2. Get the filing method id from GET /filing-methods
 * 			3. Add the filing to cart with POST /shopping-cart
 * 			4. Add card information as payment method with POST /payment-methods
 * 			5. Get payment method id from GET /payment-methods
 * 			6. Get shopping cart item id from GET /shopping-cart
 * 			7. Perform shopping cart checkout 
 * 			8. Check invoice status from GET /invoices/:invoice_id
 * 			// Optionally, skip these steps by providing 'form_data' parameter in step #3
 * 			9. Get filing form schema from GET /filing-methods/schemas
 * 			10. Get id of order item requiring client attention GET /order-items/requiring-attention
 * 			11. Add form_data to order item with POST /order-items
 **/
const DEBUG 		= process.env.DEBUG;
const COMPANY_ID	= process.env.COMPANY_ID;
const JURISDICTION 	= process.env.JURISDICTION;
let filingProductId = '';

(async () => {
	try {

		// Step 1: Get the 'EIN tax id' filing product id from GET /filing-products/offerings

		params = {
			company_id: COMPANY_ID,
		  	jurisdiction: JURISDICTION
		}

		token = baseRequest.request.token({ path: '/filing-products/offerings' });
		response = await baseRequest.request.get({ path: '/filing-products/offerings', token: token, queryParams: params });

		// choose filing product; in this example, the 'EIN tax id' product
		const einFilingProduct = response['result'].find((product) => product['filing_name'] === 'tax id');
		filingProductId = einFilingProduct['id'];

		if (DEBUG) console.log(`filing product id: ${filingProductId}`);

		// Step 2: Get the filing method id from GET /filing-methods

		params = {
			company_id: COMPANY_ID,
		  	jurisdiction: JURISDICTION,
		  	filing_product_id: filingProductId
		}

		token = baseRequest.request.token({ path: '/filing-methods' });
		response = await baseRequest.request.get({ path: '/filing-methods', token: token, queryParams: params });

		// choose a filing method
		const filingMethod = response['result'].find((method) => method['name'] === 'Standard' && method['type'] === 'online');
		const filingMethodId = filingMethod['id'];

		if (DEBUG) console.log(`Selected filing method id: ${JSON.stringify(filingMethodId)}`);

		// Step 3: Add the filing to cart with POST /shopping-cart

		// const FORM_DATA = {}; // optional, expects JSON mapping to fields of GET /filing-methods/schemas

		let body = { 
			company_id: COMPANY_ID,
			product_id: filingProductId,
			product_option_id: filingMethodId,
			quantity: 1,
			// form_data: FORM_DATA
		};

		token = baseRequest.request.token({ path: '/shopping-cart', body: body });
		response = await baseRequest.request.post({ path: '/shopping-cart', token: token, body: body });

		if (DEBUG) console.log(`Add to cart: ${JSON.stringify(response['success'])}`);

		// Step 4: Add card information as payment method with POST /payment-methods

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
				"address2": null
			}
		};
		
		token = baseRequest.request.token({ path: '/payment-methods', body: body });
		response = await baseRequest.request.post({ path: '/payment-methods', token: token, body: body });

		if (DEBUG) console.log(`Added payment method: ${JSON.stringify(response['success'])}`);

		// Step 5: Get payment method id from GET /payment-methods

		token = baseRequest.request.token({ path: '/payment-methods' });
		response = await baseRequest.request.get({ path: '/payment-methods', token: token });

		const paymentMethod = response['result'].find((method) => 
			method['last4'] === '5556' && 
			method['exp_month'] === 5 &&
			method['exp_year'] === 2029);
		const paymentMethodId = paymentMethod['id'];

		if (DEBUG) console.log(`payment method id: ${paymentMethodId}`);

		// Step 6: Get shopping cart item id from GET /shopping-cart
		// optional, can also perform checkout for all shopping cart items by company

		params = {
			company_ids: [COMPANY_ID]
		}

		token = baseRequest.request.token({ path: '/shopping-cart' });
		response = await baseRequest.request.get({ path: '/shopping-cart', token: token, queryParams: params });
		// choose shopping cart item
		const shoppingCartItem = response['result'].find((item) => 
			item['product_id'] === filingProductId && 
			item['product_option_id'] === filingMethodId &&
			item['company_id'] === COMPANY_ID &&
			item['title'] === 'Tax id filing service - Standard'
		);

		const shoppingCartItemId = shoppingCartItem['id']
		if (DEBUG) console.log(`shopping cart item id: ${shoppingCartItemId}`);

		// Step 7: Perform shopping cart checkout 

		body = { 
			// company_ids: [COMPANY_ID], // would include all items from the company's shopping cart
			item_ids: [shoppingCartItemId],
			payment_token: paymentMethodId
		};

		token = baseRequest.request.token({ path: '/shopping-cart/checkout', body: body });
		response = await baseRequest.request.post({ path: '/shopping-cart/checkout', token: token, body: body });

		if (DEBUG) console.log(`shopping cart checkout: success=${response['success']} invoices=${JSON.stringify(response['invoice_ids'])}`);

		const invoiceId = response['invoice_ids'][0];

		// Step 8: Check invoice status from GET /invoices/:invoice_id

		token = baseRequest.request.token({ path: `/invoices/${invoiceId}` });
		response = await baseRequest.request.get({ path: `/invoices/${invoiceId}`, token: token });

		if (DEBUG) console.log(`invoice status: ${JSON.stringify(response['result']['status'])}`);

		// Step 9: Get filing form schema from GET /filing-methods/schemas

		params = {
		  company_id: COMPANY_ID,
		  filing_method_id: filingMethodId
		}

		token = baseRequest.request.token({ path: '/filing-methods/schemas' });
		response = await baseRequest.request.get({ path: '/filing-methods/schemas', token: token, queryParams: params });

		if (DEBUG) console.log(`filing method form data schema: ${JSON.stringify(response['result'])}`);

		// Step 10: Get id of order item needing form data with GET /order-items/requiring-attention

		params = {
		  company_ids: [COMPANY_ID]
		}

		token = baseRequest.request.token({ path: '/order-items/requiring-attention' });
		response = await baseRequest.request.get({ path: '/order-items/requiring-attention', token: token, queryParams: params });
		// select a EIN tax id filing for the company
		const orderItem = response['result'].find((item) => 
			item['name'] === 'Standard Federal EIN - Tax Id filing' &&
			item['company_id'] === COMPANY_ID);

		if (DEBUG) console.log(`order item requiring attention: ${JSON.stringify(orderItem)}`);

		// Step 11: Add form_data to order item with POST /order-items/requiring-attention

		// reading in example form data from file
		const currentWorkingDirectory = process.cwd();
		const filePath = `${currentWorkingDirectory}/data/form_data_ein_tax_id.json`;
		fs.readFile(filePath, 'utf8', async (err, data) => {
		 	if (err) {
		 		console.error('Error reading the JSON file:', err);
				return;
		  	}
	    	const FORM_DATA = JSON.parse(data);
	    	if (DEBUG) console.log(`form data: ${JSON.stringify(FORM_DATA)}`);
	 		
		    let body =
		      {
		        company_id: COMPANY_ID,
		        order_item_id: orderItem['id'],
		        form_data: FORM_DATA
		      };

		    token = baseRequest.request.token({ path: '/order-items/requiring-attention', body: body });
		    response = await baseRequest.request.post({ path: '/order-items/requiring-attention', token: token, body: body }); 

		    // status should now be 'new', instead of 'requiring-client-attention'
		    if (DEBUG) console.log(`Added form data to order item: ${JSON.stringify(response['result'])}`);
		});
	} catch (error) {
		console.error('Error: ', error);
	}
})();