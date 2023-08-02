<?php
require_once 'base_request.php';

// Example of PATCH /companies

// this example request will update the home_state for the specified company

$debug = true;
$company = $_ENV['COMPANY_NAME'];
$entity_type = 'Corporation';

$request_data = array(
    'company' => $company,
    'entity_type' => $entity_type,
);

$companies_data = array(
  'companies' => array($request_data)
);

$request_params = '';

$json_body = json_encode($companies_data);

send_request('PATCH', '/companies', $request_params, $json_body);
