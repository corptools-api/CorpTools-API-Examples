<?php

require 'vendor/autoload.php';
require './jwt.php';

use GuzzleHttp\Client;

$base_url = 'https://api.corporatetools.com';
$document_id = "ee068109-c2ee-431d-a0b3-9585f01fa3a8";
$request_path = "/documents/$document_id/download";
$request_params = ['limit' => 1];

$jwt = build_jwt(
    getenv('ACCESS_KEY'),
    getenv('SECRET_KEY'),
    $request_path,
);

$client = new Client([
    'base_uri' => $base_url,
    'headers' => ['Authorization' => "Bearer $jwt"],
]);

$response = $client->get(
    $request_path,
    [
        'query' => $request_params,
        'sink' => "./downloads/$document_id.pdf",
    ],
);

echo json_encode(json_decode($response->getBody()), JSON_PRETTY_PRINT);
