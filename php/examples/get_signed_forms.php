<?php
require_once 'base_request.php';

// Example of GET /signed-forms

$debug = true;
$filing_method_id   = $_ENV['FILING_METHOD_ID'];
$website_id   = $_ENV['WEBSITE_ID'];

$request_params = [
	'filing_method_id' => $filing_method_id,
	'website_id' => $website_id
];

send_request('GET', '/signed-forms', $request_params, '');