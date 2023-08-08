<?php
require_once 'base_request.php';

// Example of DELETE /payment-methods/:payment_method_id

$debug = true;
$payment_method_id = $_ENV['PAYMENT_METHOD_ID'];
$path = '/payment-methods/' . $payment_method_id;

send_request('DELETE', $path, '', '');