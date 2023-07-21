<?php
require_once 'base_request.php';

//  Example of GET /compliance-events
//  Either a company or company_id may be provided, but not both
//  Either an array of jurisdictions or jurisdiction_ids may be provided, but not both
//  Start_date and end_date are required

$debug = true;
$company_id   = $_ENV['COMPANY_ID'];
$start_date = $_ENV['START_DATE'];
$end_date = $_ENV['END_DATE'];
$request_data = '';
$request_params = ['company_id' => $company_id, 'start_date' => $start_date, 'end_date' => $end_date];

send_request('GET', '/compliance-events', $request_params, $request_data);
