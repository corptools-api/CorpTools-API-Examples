<?php
require_once 'base_request.php';

// Example of GET /filing-products/offerings

$debug = true;
$jurisdiction = $_ENV['JURISDICTION'];
$company_id   = $_ENV['COMPANY_ID'];
$request_data = '';
$request_params = ['jurisdiction' => $jurisdiction, 'company_id' => $company_id];

send_request('GET', '/filing-products/offerings', $request_params, $request_data);