<?php
require_once 'base_request_curl.php';

$debug = true;
$request_data = '';
$request_params = ['names' => ['Test Company 2']];

send_request('GET', '/companies', $request_params, $request_data);