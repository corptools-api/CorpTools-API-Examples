<?php
require_once 'base_request.php';

// Example of GET /documents

$debug = true;
$status   = $_ENV['STATUS'];
$request_data = '';
$request_params = ['status' => $status];

send_request('GET', '/documents', $request_params, $request_data);
