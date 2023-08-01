<?php
require_once 'base_request.php';

// Example of POST /auth/forgot-password

$debug = true;
$email = $_ENV['EMAIL'];
// $subdomain = $_ENV['SUBDOMAIN'];    // optional
$website_id = $_ENV['WEBSITE_ID'];  // optional

$request_data = array(
    'email_address' => $email,
    'website_id' => $website_id
);

$request_params = '';

$json_body = json_encode($request_data);

send_request('POST', '/auth/forgot-password', $request_params, $json_body);