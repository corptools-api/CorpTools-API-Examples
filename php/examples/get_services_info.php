<?php
require_once 'base_request.php';

// Example of GET /services/:id/info

$debug = true;
$service_id   = $_ENV['SERVICE_ID'];

send_request('GET', '/services/' . $service_id . '/info', [], '');