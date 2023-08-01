<?php
require_once 'base_request.php';

// Example of GET /documents/bulk-download

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$request_data = '';
$request_params = ['ids' => [$document_id]];

send_request('GET', '/documents/bulk-download', $request_params, $request_data);
