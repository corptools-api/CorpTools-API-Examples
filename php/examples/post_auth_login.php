<?php
require_once 'base_request.php';

// Example of POST /auth/login

$debug = true;
$email = $_ENV['EMAIL'];
$password = $_ENV['PASSWORD'];
$website_id = $_ENV['WEBSITE_ID'];  // optional

$request_data = array(
    'email' => $email,
    'password' => $password,
    'website_id' => $website_id
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/auth/login', $request_params, $json_body);