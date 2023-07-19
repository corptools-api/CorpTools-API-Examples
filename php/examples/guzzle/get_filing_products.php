<?php
require_once 'base_request_curl.php';

$debug = true;
$jurisdiction = $_ENV['JURISDICTION'];
$url   = $_ENV['WEBSITE_URL'];
$request_data = '';
$request_params = ['jurisdiction' => $jurisdiction, 'url' => $url];

send_request('GET', '/filing-products', $request_params, $request_data);