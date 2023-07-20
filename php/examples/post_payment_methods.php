<?php
require_once 'base_request.php';

// Example of POST /payment-methods

$debug = true;
$card_number = '2223003122003222';
$exp_month = '12';		
$exp_year = '2028';					
$cvc = '321';
$first_name = 'Oscar';
$last_name = 'Grouch';
$billing_address = array(
    "city" =>  "New York",
    "state" =>  "NY",
    "zip" =>  "10463",
    "country" =>  "US",
    "address1" =>  "1213 Seasame Street",
    "address2" =>  ""
  );

$request_data = array(
	'number' => $card_number,
	'exp_month' =>  $exp_month,
	'exp_year' =>  $exp_year,
	'cvc' => $cvc,
	'first_name' => $first_name,
	'last_name' =>  $last_name,
	'billing_address' =>  $billing_address
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/payment-methods', $request_params, $json_body);