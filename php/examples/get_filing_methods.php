<?php
require_once 'base_request.php';

// Example of GET /filing-methods

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$jurisdiction = $_ENV['JURISDICTION'];
$product_id = $_ENV['FILING_PRODUCT_ID'];
$request_data = '';
$request_params = ['company_id' => $company_id, 'jurisdiction' => $jurisdiction, 'filing_product_id' => $product_id];

send_request('GET', '/filing-methods', $request_params, $request_data);