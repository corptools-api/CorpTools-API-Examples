<?php
require_once 'base_request.php';

// Example of GET /websites

$debug = true;
$website_url   = $_ENV['WEBSITE_URL'];
$request_data = '';
$request_params = ['url' => $website_url];

send_request('GET', '/websites', $request_params, $request_data);
