<?php
require_once 'base_request.php';

// Example of GET /payment-methods

$debug = true;
$request_data = '';
$request_params = [];

send_request('GET', '/payment-methods', $request_params, $request_data);