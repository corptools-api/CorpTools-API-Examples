<?php
require_once 'base_request.php';

// Example of POST /shopping-cart

$debug = true;
$company_id 		= $_ENV['COMPANY_ID'];
$filing_product_id  = $_ENV['FILING_PRODUCT_ID'];
$filing_method_id 	= $_ENV['FILING_METHOD_ID'];
$quantity = 1;
// $form_data = {}; // optional, expects JSON mapping to fields of filing method schema

$request_data = array(
    'company_id' => $company_id,
    'product_id' => $filing_product_id,
    'product_option_id' => $filing_method_id,
    'quantity' => 1
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/shopping-cart', $request_params, $json_body);