<?php

// This is a standalone file.
// It does not require any other files and does not need composer.

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

/*
 * Convert Array of Parameters to Query String
 */
function query_string($request_params) {
    $qs = http_build_query($request_params, '');
    $qs = preg_replace('/%5B[0-9]+%5D/simU', '%5B%5D', $qs);
    if (!empty($qs)) {
        $qs = '?' . $qs;
    }

    if ($GLOBALS['debug']) echo 'Query String: ' . $qs . PHP_EOL;

    return $qs;
}

/*
 * Build out your Json Web Token
 */
function build_jwt($access_key, $secret_key, $request_path, $request_data = null) {
    $header = json_encode([
      'typ' => 'JWT',
      'alg' => 'HS256',
      'access_key' => $access_key,
    ]);
    $payload = json_encode([
      'path' => $request_path,
      'content' => hash('sha256', $request_data),
    ]);

    $e_header = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($header));
    $e_payload = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($payload));
    $signature = hash_hmac('sha256', $e_header . '.' . $e_payload, $secret_key, true);
    $e_signature = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($signature));
    $jwt = $e_header . '.' . $e_payload . '.' . $e_signature;

    if ($GLOBALS['debug']) echo 'JWT: ' . $jwt . PHP_EOL;

    return $jwt;
}

/*
 * Call the api using curl
 */
function call_api_curl($method, $url, $jwt, $data = null) {
    $ch = curl_init();

    switch ($method) {
        case "POST":
            curl_setopt($curl, CURLOPT_POST, 1);

            if ($data) {
                curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
            }
            break;
        default:
            break;
    }

    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_HTTPHEADER, [
      "Authorization: Bearer $jwt",
      "Content-Type: application/json",
      "Accept: application/json"
    ]);

    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
    curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
    curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 10);
    curl_setopt($ch, CURLOPT_TIMEOUT, 10);

    $result = curl_exec($ch);

    $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
    $http_res_code = curl_getinfo($ch, CURLINFO_RESPONSE_CODE);

    if (curl_errno($ch)) {
        die('Error:' . curl_error($ch) . PHP_EOL);
    }

    if (!empty($http_res_code) && $http_res_code <> 200) {
        die("Response Code: ${http_res_code}");
    }

    curl_close($ch);

    return $result;
}

$jwt = build_jwt($access_key, $secret_key, $request_path, $request_data);
$qs = query_string($request_params);
$url = $base_url . $request_path . $qs;
if ($debug) echo 'URL: ' . $url . PHP_EOL;

$result = call_api_curl('GET', $url, $jwt);
echo json_encode(json_decode($result), JSON_PRETTY_PRINT);
