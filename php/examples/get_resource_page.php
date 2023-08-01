<?php
require_once 'base_request.php';

// Example of GET /resources/:id/page/:page

$debug = true;
$resource_id = $_ENV['AGENCY_RESOURCE_ID'];
$page = $_ENV['PAGE_NUMBER'];
$request_data = '';
$request_params = [];
$url_path = '/resources/' . $resource_id . '/page/' . $page;

send_request('GET', $url_path, $request_params, $request_data);