<?php
require_once 'base_request.php';

// Example of GET /services

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$company_name   = $_ENV['COMPANY_NAME'];
$limit = 3;
$offset = 0;
$request_data = '';
$request_params = [
	'company_id' => $company_id,
	// 'company' => $company,
	// 'limit' => $limit,
	// 'offset' => $offset
];

send_request('GET', '/services', $request_params, $request_data);