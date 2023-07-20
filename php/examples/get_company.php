<?php
require_once 'base_request.php';

// Example of GET /companies/company_id

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$request_data = '';
$request_params = [];
// TODO: how Guzzle sends array query params is received by Ruby as indifferent access Hash
// $request_params = ['names' => ['Test Company 2']];

send_request('GET', '/companies/' . $company_id, $request_params, $request_data);