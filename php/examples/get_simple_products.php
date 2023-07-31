<?php
require_once 'base_request.php';

// Example of GET /simple-products

$debug = true;
$website_url   = $_ENV['WEBSITE_URL'];
$request_data = '';
$request_params = ['url' => $website_url];

send_request('GET', '/simple-products', $request_params, $request_data);