<?php
require_once 'base_request.php';

// Example of POST /services/:id/cancel-request

$debug = true;
$service_id = $_ENV['SERVICE_ID'];

$request_data = '';
$request_params = '';
$url_path = '/services/' . $service_id . '/cancel-request';

send_request('POST', $url_path, $request_params, $request_data);