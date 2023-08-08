<?php
require_once 'base_request.php';

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

$debug = (bool) $_ENV['DEBUG'];
$jurisdiction = $_ENV['JURISDICTION'];
$company_id   = $_ENV['COMPANY_ID'];

// Step 1: Get the filing product id from GET /filing-products/offerings

$request_data = '';
$request_params = ['jurisdiction' => $jurisdiction, 'company_id' => $company_id];

$response = send_request('GET', '/filing-products/offerings', $request_params, $request_data);

foreach ($response['result'] as $product) {
    if ($product['filing_name'] === 'tax id') {
        $product_id = $product['id'];
        break;
    }
}

if ($debug === true) { 
	echo "filing product id: {$product_id}\n";
}

// Step 2: Get the filing method id from GET /filing-methods

$request_data = '';
$request_params = ['company_id' => $company_id, 'jurisdiction' => $jurisdiction, 'filing_product_id' => $product_id];

$response = send_request('GET', '/filing-methods', $request_params, $request_data);

foreach ($response['result'] as $method) {
    if ($method['name'] === 'Standard' && $method['type'] === 'online') {
        $filing_method_id = $method['id'];
        break;
    }
}

if ($debug === true) { 
	echo "filing method id: {$filing_method_id}\n"; 
}

// Step 3: Add the filing to cart with POST /shopping-cart

$request_data = array(
    'company_id' => $company_id,
    'product_id' => $product_id,
    'product_option_id' => $filing_method_id,
    'quantity' => 1
);

$request_params = '';
$json_body = json_encode($request_data);
$response = send_request('POST', '/shopping-cart', $request_params, $json_body);

if ($debug === true) { 
	echo 'Add to cart: ';
	print_r($response);
}

// Step 4: Add card information as payment method with POST /payment-methods

$billing_address = array(
    "city" =>  "New York",
    "state" =>  "NY",
    "zip" =>  "10463",
    "country" =>  "US",
    "address1" =>  "1213 Seasame Street",
    "address2" =>  ""
  );

$request_data = array(
	'number' => '2223003122003222',
	'exp_month' =>  '12',
	'exp_year' =>  '2028',
	'cvc' => '321',
	'first_name' => 'Example',
	'last_name' =>  'Test',
	'billing_address' =>  $billing_address
);

$request_params = '';
$json_body = json_encode($request_data);
$response = send_request('POST', '/payment-methods', $request_params, $json_body);

if ($debug === true) { 
	echo 'Add payment method: ';
	print_r($response);
}

// Step 5: Get payment method id from GET /payment-methods

$request_data = '';
$request_params = [];
$response = send_request('GET', '/payment-methods', $request_params, $request_data);

foreach ($response['result'] as $method) {
    if ($method['last4'] === '3222' && $method['exp_month'] === 12 && $method['exp_year'] === 2028) {
        $payment_method_id = $method['id'];
        break;
    }
}

if ($debug === true) { 
	echo 'payment method id: ';
	print_r($payment_method_id);
}

// Step 6: Get shopping cart item id from GET /shopping-cart

$request_data = '';
$request_params = ['company_ids' => [$company_id]];

$response = send_request('GET', '/shopping-cart', $request_params, $request_data);
foreach ($response['result'] as $item) {
	if ($item['product_id'] === $product_id &&
		$item['product_option_id'] === $filing_method_id &&
		$item['company_id'] === $company_id &&
		$item['title'] === 'Tax id filing service - Standard' &&
		$item['status'] === 'active') {
		$shopping_cart_item_id = $item['id'];
		break;
	}
}

if ($debug === true) { 
	echo "shopping cart item id: {$shopping_cart_item_id}\n";
}

// Step 7: Perform shopping cart checkout

$item_ids    = array($shopping_cart_item_id);
$company_ids = array($company_id);

$request_data = array(
    // 'company_ids'   => $company_ids,
    'item_ids'      => $item_ids,
    'payment_token' => $payment_method_id
);

$request_params = '';
$json_body = json_encode($request_data);
$response = send_request('POST', '/shopping-cart/checkout', $request_params, $json_body);

$invoice_id = $response['invoice_ids'][0];

if ($debug === true) { 
	echo "invoice id: {$invoice_id}\n";
}

// Step 8: Check invoice status from GET /invoices/:invoice_id

$request_data = '';
$request_params = [];

$response = send_request('GET', '/invoices/' . $invoice_id, $request_params, $request_data);

$invoice_status = $response['result']['status'];

if ($debug === true) { 
	echo "invoice status: {$invoice_status}\n";
}

// Step 9: Get filing form schema from GET /filing-methods/schemas

$request_data = '';
$request_params = ['company_id' => $company_id, 'filing_method_id' => $filing_method_id];
$response = send_request('GET', '/filing-methods/schemas', $request_params, $request_data);

if ($debug === true) { 
	echo "form data schema: ";
	print_r($response);
}

// Step 10: Get id of order item requiring client attention GET /order-items/requiring-attention

$request_data = '';
$request_params = ['company_ids' => [$company_id]];
$response = send_request('GET', '/order-items/requiring-attention', $request_params, $request_data);

foreach ($response['result'] as $item) {
	if ($item['name'] ==='Standard Federal EIN - Tax Id filing' &&
		$item['company_id'] === $company_id) {
		$order_item_id = $item['id'];
		break;
	}
}

if ($debug === true) { 
	echo "order item requiring attention: {$order_item_id}\n";
}

// Step 11: Add form_data to order item with POST /order-items

$file_path = '../data/form_data_ein_tax_id.json';
$json_data = file_get_contents($file_path);
$form_data = json_decode($json_data);

$request_data = array(
    'company_id'    => $company_id,
    'order_item_id' => $order_item_id,
    'form_data'     => $form_data
);

$request_params = '';
$json_body = json_encode($request_data);
$response = send_request('POST', '/order-items/requiring-attention', $request_params, $json_body);

if ($debug === true) { 
	echo "Added form data to order item: ";
	print_r($response);
}