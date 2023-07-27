<?php
require_once 'base_request.php';

// Example of POST /order-items/requiring-attention

$debug = true;
$company_id = $_ENV['COMPANY_ID'];
$order_item_id = $_ENV['ORDER_ITEM_ID'];

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

send_request('POST', '/order-items/requiring-attention', $request_params, $json_body);