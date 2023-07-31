<?php
require_once 'base_request.php';

// Example of GET /documents/:document_id/page/:page_number/url

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$page_number = $_ENV['PAGE_NUMBER'];
$request_data = '';
$request_params = [];

send_request('GET', '/documents/' . $document_id . '/page/' . $page_number . '/url', $request_params, $request_data);
