<?php
require_once 'base_request.php';

// Example of GET /documents/:document_id/download

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$request_data = '';
$request_params = [];

send_request('GET', '/documents/' . $document_id . '/download', $request_params, $request_data);
