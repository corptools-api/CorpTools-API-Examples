<?php
$access_key = '<your access key>';
$secret_key = '<your secret key>';
$base_url = 'https://api.corporatetools.com';
$request_path = '/companies';
$query_string = '';
$request_body = json_encode([
  'companies' => [
    [
      'name' => 'Sample Z',
      'jurisdictions' => ['California', 'Wyoming'],
      'entity_type' => 'Limited Liability Company'
    ]
  ]
]);
$header = json_encode([
  'typ' => 'JWT',
  'alg' => 'HS256',
  'access_key' => $access_key
]);
$payload = json_encode([
  'path' => $request_path,
  'content' => hash('sha256', $query_string . $request_body)
]);
$e_header = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($header));
$e_payload = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($payload));
$signature = hash_hmac('sha256', $e_header . '.' . $e_payload, $secret_key, true);
$e_signature = str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($signature));
$jwt = $e_header . '.' . $e_payload . '.' . $e_signature;
$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $base_url . $request_path);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $request_body);
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, [
  "Authorization: Bearer $jwt",
  'Content-Type: application/json',
  'Accept: application/json'
]);
$result = curl_exec($ch);
var_dump($result);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
}
curl_close ($ch);
?>
