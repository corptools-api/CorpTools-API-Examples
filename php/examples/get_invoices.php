<?php
require_once 'base_request.php';

// Example of GET /invoices
// An array of company names or company_ids may be provided, but not both

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$request_data = '';
$request_params = ['company_ids' => [$company_id]];

send_request('GET', '/invoices', $request_params, $request_data);
