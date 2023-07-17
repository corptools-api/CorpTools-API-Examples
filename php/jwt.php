<?php

/*
 * Build out your Json Web Token
 */
function build_jwt($access_key, $secret_key, $request_path, $request_data = '') {
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
