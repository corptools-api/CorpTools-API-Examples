<?php
// Loading .env environment properties
require __DIR__ . '/vendor/autoload.php';
$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->safeLoad();

require './jwt.php';

use GuzzleHttp\Client;
use GuzzleHttp\Exception\ClientException;

function send_request($method, $request_path, $request_params, $request_data, $content_type = 'application/json') {
    $access_key = $_ENV['ACCESS_KEY'];
    $secret_key = $_ENV['SECRET_KEY'];
    $base_url = $_ENV['API_URL'];

    if ($GLOBALS['debug']) echo 'Guzzle: access_key=' . $access_key . ' secret_key=' . $secret_key . ' base_url=' . $base_url;

    $jwt = build_jwt($access_key, $secret_key, $request_path, $request_data);

    $client = new Client([
        'base_uri' => $base_url,
        'headers' => [
            'Authorization' => "Bearer $jwt",
        ],
    ]);

    $response = null;

    if ($method == 'DELETE') {
        $response = delete_request($client, $request_path, $request_params);
    } else if ($method == 'GET') {
        $response = get_request($client, $request_path, $request_params);
    } else if ($method == 'PATCH') {
        $response = patch_request($client, $request_path, $request_data);
    } else if ($method == 'POST') {
        $response = post_request($client, $request_path, $request_data);
    }
    if ($response != null) {
        $content_type = $response->getHeaderLine('content-type');
        $response_filename = strtolower($method) . str_replace(['/'], ['_'], $request_path) . '_response';
        if (strpos($content_type, 'application/json') !== false) {
            echo json_encode(json_decode($response->getBody()), JSON_PRETTY_PRINT);
        } elseif (strpos($content_type, 'image/png') !== false) {
            file_put_contents("./documents/{$response_filename}.png", $response->getBody());
            echo "PNG image saved as {$response_filename}.png";
        } elseif (strpos($content_type, 'application/pdf') !== false) {
            file_put_contents("./documents/{$response_filename}.pdf", $response->getBody());
            echo "PDF file saved as {$response_filename}.pdf";
        } else {
            echo $response->getBody();
        }
    }
}

function delete_request($client, $request_path, $request_params)
{
    try {
        $qs = '';
        if (is_array($request_params)) {
            $qs = http_build_query($request_params, '');
            $qs = preg_replace('/%5B[0-9]+%5D/simU', '%5B%5D', $qs);
        }
        if ($GLOBALS['debug']) echo 'Guzzle: DELETE ' . $request_path . ' ' . $qs . PHP_EOL;
        $response = $client->delete(
            $request_path,
            [
                'query' => $qs,
            ],
        );
        return $response;
    } catch (ClientException $e) {
        handle_error($e);
    }
}

function get_request($client, $request_path, $request_params)
{
    try {
        $qs = http_build_query($request_params, '');
        $qs = preg_replace('/%5B[0-9]+%5D/simU', '%5B%5D', $qs);
        if ($GLOBALS['debug']) echo 'Guzzle: GET ' . $request_path . ' ' . $qs . PHP_EOL;
        $response = $client->get(
            $request_path,
            [
                'query' => $qs,
            ],
        );

        return $response;
    } catch (ClientException $e) {
        handle_error($e);
    }
}

function post_request($client, $request_path, $request_data)
{
    // Convert the JSON string to a PHP associative array
    $data = json_decode($request_data, true);
    try {
        if ($GLOBALS['debug']) echo 'Guzzle: POST ' . $request_path . ' ' . $request_data . PHP_EOL;
        $response = $client->post(
            $request_path,
            [
                'json' => $data,
            ],
        );

        return $response;
    } catch (ClientException $e) {
        handle_error($e);
    }
}

function patch_request($client, $request_path, $request_data)
{
    // Convert the JSON string to a PHP associative array
    $data = json_decode($request_data, true);
    try {
        if ($GLOBALS['debug']) echo 'Guzzle: PATCH ' . $request_path . ' ' . $request_data . PHP_EOL;
        $response = $client->patch(
            $request_path,
            [
                'json' => $data,
            ],
        );

        return $response;
    } catch (ClientException $e) {
        handle_error($e);
    }
}

function handle_error($e)
{
    $status_code = $e->getResponse()->getStatusCode();
    $response_body = $e->getResponse() ? $e->getResponse()->getBody()->getContents() : '';
    echo 'Response Error: code=' . $status_code . ' message=' . $response_body . PHP_EOL;
}
