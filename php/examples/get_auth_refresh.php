<?php
require_once 'base_request.php';

// Example of GET /auth/refresh

$debug = true;
$request_data = '';
$request_params = [];

send_request('GET', '/auth/refresh', $request_params, $request_data);