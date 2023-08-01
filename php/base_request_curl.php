<?php
// Loading .env environment properties
require __DIR__ . '/vendor/autoload.php';
$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->safeLoad();

function send_request($method, $request_path, $request_params, $request_data, $content_type = 'application/json') {
    $access_key = $_ENV['ACCESS_KEY'];
    $secret_key = $_ENV['SECRET_KEY'];
    $base_url   = $_ENV['API_URL'];

    if ($GLOBALS['debug']) echo 'Curl: access_key=' . $access_key . ' secret_key=' . $secret_key . ' base_url=' . $base_url . PHP_EOL;
    $jwt = build_jwt($access_key, $secret_key, $request_path, $request_data);

    if ($request_data == '') {
        if ($request_params == '') {
            $url = $base_url . $request_path; 
        } else {
            $qs = query_string($request_params);
            $url = $base_url . $request_path . $qs;
        }
    } else {
        $url = $base_url . $request_path; 
    }

    if ($GLOBALS['debug']) echo $method . ' ' . $url . PHP_EOL;

    $response = call_api_curl($method, $url, $jwt, $request_data, $content_type);
    $content_type = $response['content-type'];
    $result = $response['result'];

    $response_filename = strtolower($method) . str_replace(['/'], ['_'], $request_path) . '_response';

    if (strpos($content_type, 'application/json') !== false) {
        echo json_encode(json_decode($result), JSON_PRETTY_PRINT);
    } elseif (strpos($content_type, 'image/png') !== false) {
        $png_file_path = __DIR__ . "/documents/{$$response_filename}.png";
        if (file_put_contents($png_file_path, $result) === false) {
            die("Error: Unable to save PNG file");
        }
        echo "PNG image saved as {$response_filename}.png";
    } elseif (strpos($content_type, 'application/pdf') !== false) {
        $pdf_file_path = __DIR__ . "/documents/{$response_filename}.pdf";
        if (file_put_contents($pdf_file_path, $result) === false) {
            die("Error: Unable to save PDF file");
        }
        echo "PDF file saved as {$response_filename}.pdf";
    } else {
        echo $result;
    }
}

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
function call_api_curl($method, $url, $jwt, $data = null, $content_type) {
    $ch = curl_init();

    if ($GLOBALS['debug']) echo 'Curl: ' . $method . ' ' . $url . ' ' . $data . PHP_EOL;

    switch ($method) {
        case "DELETE":
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'DELETE');
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
            break;
        case "PATCH":
            curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'PATCH');
            if ($data) {
                curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
            }
            break;
        case "POST":
            curl_setopt($ch, CURLOPT_POST, 1);
            if ($data) {
                curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
            }
            break;
        default:
            break;
    }

    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_HTTPHEADER, [
      "Authorization: Bearer $jwt",
      "Content-Type: $content_type",
      "Accept: application/json"
    ]);

    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
    curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
    curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 20);
    curl_setopt($ch, CURLOPT_TIMEOUT, 20);
    curl_setopt($ch, CURLOPT_HEADER, true);
    curl_setopt($ch, CURLOPT_HEADER, true);

    $response = curl_exec($ch);
    $headerSize = curl_getinfo($ch, CURLINFO_HEADER_SIZE);
    $headers = substr($response, 0, $headerSize);
    $content_type_response = '';

    $header_lines = explode("\r\n", $headers);
    foreach ($header_lines as $line) {
        if (strpos($line, 'content-type:') !== false) {
            $content_type_response = trim(explode(':', $line, 2)[1]);
            break;
        }
    }

    $result = substr($response, $headerSize);
    $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
    $http_res_code = curl_getinfo($ch, CURLINFO_RESPONSE_CODE);

    if (curl_errno($ch)) {
        die('Error:' . curl_error($ch) . PHP_EOL);
    }

    if (!empty($http_res_code) && $http_res_code <> 200) {
        die("Response Code: {$http_res_code}");
    }

    curl_close($ch);

    return ['content-type' => $content_type_response, 'result' => $result];
}
