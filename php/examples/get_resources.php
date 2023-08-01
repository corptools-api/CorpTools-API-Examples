<?php
require_once 'base_request.php';

// Example of GET /resources

$debug = true;

$request_data = '';
$request_params = [];

send_request('GET', '/resources', $request_params, $request_data);