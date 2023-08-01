<?php
require_once 'base_request.php';

// Example of POST /auth/reset-password

$debug = true;
$token = $_ENV['RESET_PASSWORD_TOKEN'];
$password= $_ENV['PASSWORD'];

$request_data = array(
    'token' => $token,
    'password' => $password,
    'password_confirmation' => $password
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/auth/reset-password', $request_params, $json_body);