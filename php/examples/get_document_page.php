<?php
require_once 'base_request.php';

// Example of GET /documents/:document_id/page/:page_number
// The specified page of the document is saved as a png in the 'documents' directory

$debug = true;
$document_id   = $_ENV['DOCUMENT_ID'];
$page_number = $_ENV['PAGE_NUMBER'];
$request_data = '';
$content_type = 'image/png';
$request_params = [];

send_request('GET', '/documents/' . $document_id . '/page/' . $page_number, $request_params, $request_data, $content_type);
