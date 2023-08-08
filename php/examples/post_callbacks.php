<?php
require_once 'base_request.php';

// Example of POST /callbacks

$debug = true;
$url = $_ENV['CALLBACK_URL'];

$request_data = array(
    'url' => $url
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/callbacks', $request_params, $json_body);