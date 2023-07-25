<?php
require_once 'base_request.php';

// Example of DELETE /shopping-cart

$debug = true;
$shopping_cart_item_id = $_ENV['SHOPPING_CART_ITEM_ID'];
$company_id = $_ENV['COMPANY_ID'];
$request_params = array(
	'company_ids' => [$company_id],
	'item_ids' => [$shopping_cart_item_id]
);

$request_data = '';

$json_body = json_encode($request_params);

send_request('DELETE', '/shopping-cart', $request_params,  $request_data);