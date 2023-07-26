<?php
require_once 'base_request.php';

// Example of POST /shopping-cart/checkout

$debug = true;
$company_id         = $_ENV['COMPANY_ID'];
$item_id            = $_ENV['SHOPPING_CART_ITEM_ID'];
$payment_method_id  = $_ENV['PAYMENT_METHOD_ID'];

$item_ids    = array($item_id);
$company_ids = array($company_id);

$request_data = array(
    'company_ids'   => $company_ids,
    'item_ids'      => $item_ids,
    'payment_token' => $payment_method_id
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/shopping-cart/checkout', $request_params, $json_body);