<?php
require_once 'base_request.php';

// Example of DELETE /payment-methods/:id

$debug = true;
$payment_method_id = $_ENV['PAYMENT_METHOD_ID'];
$request_params = [];
$request_data = '';
$json_body = json_encode($request_data);

$path = '/payment-methods/' . $payment_method_id;

send_request('DELETE', $path, $request_params, $json_body);