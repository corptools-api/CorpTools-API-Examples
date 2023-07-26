<?php
require_once 'base_request.php';

// Example of GET /order-items/requiring-attention

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$request_data = '';
$request_params = ['company_ids' => [$company_id]];

send_request('GET', '/order-items/requiring-attention', $request_params, $request_data);