<?php
require_once 'base_request.php';

// Example of DELETE /callbacks/:callback_id

$debug = true;
$callback_id = $_ENV['CALLBACK_ID'];
$path = '/callbacks/' . $callback_id;

send_request('DELETE', $path, '', '');