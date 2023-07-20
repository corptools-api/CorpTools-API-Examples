<?php
require_once 'base_request.php';

// Example of POST /companies

$debug = true;
$company_name 		= $_ENV['COMPANY_NAME'];
$home_state       = $_ENV['JURISDICTION'];
$entity_type 	    = $_ENV['ENTITY_TYPE'];

$request_data = array(
    'name' => $company_name,
    'home_state' => $home_state,
    'entity_type' => $entity_type,
);

$companies_data = array(
  'companies' => array($request_data)
);

$request_params = '';

$json_body = json_encode($companies_data);

send_request('POST', '/companies', $request_params, $json_body);