<?php
// Loading .env environment properties
require __DIR__ . '/vendor/autoload.php';
$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->safeLoad();

require './jwt.php';

use GuzzleHttp\Client;

function send_request($method, $request_path, $request_params, $request_data) {
    $access_key = $_ENV['ACCESS_KEY'];
    $secret_key = $_ENV['SECRET_KEY'];
    $base_url = $_ENV['API_URL'];

    echo 'access_key=' . $access_key . ' secret_key=' . $secret_key . ' base_url=' . $base_url;

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
}