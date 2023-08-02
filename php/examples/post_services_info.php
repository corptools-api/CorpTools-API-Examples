<?php
require_once 'base_request.php';

// Example of POST /services/:service_id/info

$debug = true;
$service_id = $_ENV['SERVICE_ID'];

$file_path = '../data/services/add_info_corp.json';
$service_info = file_get_contents($file_path);
$request_body = json_decode($service_info);
$request_params = '';

$path = '/services/' . $service_id . '/info';

send_request('POST', $path, $request_params, json_encode($request_body));