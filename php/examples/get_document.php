<?php
require_once 'base_request.php';

// Example of GET /documents/:document_id

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$request_data = '';
$request_params = [];

send_request('GET', '/documents/' . $document_id, $request_params, $request_data);
