<?php
require_once 'base_request.php';

// Example of GET /filing-methods/schemas

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$method_id = $_ENV['FILING_METHOD_ID'];
$request_data = '';
$request_params = ['company_id' => $company_id, 'filing_method_id' => $method_id];

send_request('GET', '/filing-methods/schemas', $request_params, $request_data);
