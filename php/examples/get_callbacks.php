<?php
require_once 'base_request.php';

// Example of GET /callbacks

$debug = true;
$request_data = '';
$request_params = [];

send_request('GET', '/callbacks', $request_params, $request_data);