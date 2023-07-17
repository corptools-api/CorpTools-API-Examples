<?php
// Loading .env environment properties
require __DIR__ . '/vendor/autoload.php';
$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->safeLoad();

require './jwt.php';

use GuzzleHttp\Client;

/*
 * Define variables
 */
$debug = false;
$base_url = $_ENV['API_URL'];
$document_id = $_ENV['DOCUMENT_ID'];
$request_path = "/documents/$document_id/download";
$request_params = ['limit' => 1];

$jwt = build_jwt(
    $_ENV['ACCESS_KEY'],
    $_ENV['SECRET_KEY'],
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
