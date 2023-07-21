<?php
require_once 'base_request.php';

// Example of PATCH /payment-methods/:id

$debug = true;
$payment_method_id = $_ENV['PAYMENT_METHOD_ID'];
$card_number = '2223003122003222';
$exp_month = '10';		
$exp_year = '2031';					
$cvc = '368';
$first_name = 'Oscar';
$last_name = 'Grouch';
$billing_address = array(
    "city" =>  "New York",
    "state" =>  "NY",
    "zip" =>  "36401",
    "country" =>  "US",
    "address1" =>  "5643 Seasame Street",
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

$request_params = null;

$json_body = json_encode($request_data);

send_request('PATCH', "/payment-methods/$payment_method_id", $request_params, $json_body);