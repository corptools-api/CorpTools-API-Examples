<?php
require_once 'base_request.php';

// Example of GET /shopping-cart

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$request_data = '';
$request_params = ['company_ids' => [$company_id]];

send_request('GET', '/shopping-cart', $request_params, $request_data);