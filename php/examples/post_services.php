<?php
require_once 'base_request.php';

// Example of POST /services

$debug = true;
$company_id = $_ENV['COMPANY_ID'];
$jurisdiction_id = $_ENV['JURISDICTION_ID'];

$jurisdiction_ids = array($jurisdiction_id);

$request_data = array(
    'company_id' => $company_id,
    'jurisdiction_ids' => $jurisdiction_ids
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/services', $request_params, $json_body);