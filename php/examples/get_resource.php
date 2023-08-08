<?php
require_once 'base_request.php';

// Example of GET /resources/:resource_id

$debug = true;
$resource_id = $_ENV['AGENCY_RESOURCE_ID'];
$request_data = '';
$request_params = [];
$url_path = '/resources/' . $resource_id;

send_request('GET', $url_path, $request_params, $request_data);