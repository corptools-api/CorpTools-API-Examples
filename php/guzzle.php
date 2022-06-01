<?php

require 'vendor/autoload.php';
require './jwt.php';

use GuzzleHttp\Client;

/*
 * Define variables
 */
$debug = false;
$access_key = getenv('ACCESS_KEY');
$secret_key = getenv('SECRET_KEY');
// $base_url = 'https://api.corporatetools.com';
$base_url = 'http://127.0.0.1:9292';
$request_path = '/companies';
$request_data = null;
// $request_params = [];
// $request_params = ['names' => ['Test CT Integration Company 2']];
// $request_params = ['offset' => 2, 'limit' => 1];
$request_params = ['limit' => 1];

$jwt = build_jwt($access_key, $secret_key, $request_path, $request_data);

$client = new Client([
    'base_uri' => $base_url,
    'headers' => [
        'Authorization' => "Bearer $jwt",
    ],
]);

$response = $client->get(
    $request_path,
    [
        'query' => $request_params,
    ],
);

echo json_encode(json_decode($response->getBody()), JSON_PRETTY_PRINT);
