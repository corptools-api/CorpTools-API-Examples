<?php
require_once 'base_request.php';

// Example of GET /documents/:document_id/download
// The specified document is saved as a pdf in the 'documents' directory

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$request_data = '';
$request_params = [];

send_request('GET', '/documents/' . $document_id . '/download', $request_params, $request_data);
