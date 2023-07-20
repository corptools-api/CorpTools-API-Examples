<?php
require_once 'base_request.php';

// Example of GET /companies

$debug = true;
$request_data = '';
$request_params = [];
// TODO: how Guzzle sends array query params is received by Ruby as indifferent access Hash
// $request_params = ['names' => ['Test Company 2']];

send_request('GET', '/companies', $request_params, $request_data);