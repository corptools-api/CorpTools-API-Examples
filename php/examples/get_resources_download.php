<?php
require_once 'base_request.php';

// Example of GET /resources/:resource_id/download
// The specified resource is saved as a pdf in the 'documents' directory

$debug = true;
$resource_id   = $_ENV['AGENCY_RESOURCE_ID'];
$request_data = '';
$request_params = [];

send_request('GET', '/resources/' . $resource_id . '/download', $request_params, $request_data);
