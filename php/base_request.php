<?php
// Loads either Curl or Guzzle base request send_request function, 
// depending on 'curl' or 'guzzle' flag from composer.json script

$args = $argv;
array_shift($args); // skipping first arg, the name of script
if ($args[0] == 'curl') {
    require_once 'base_request_curl.php';
} else if ($args[0] == 'guzzle') {
    require_once 'base_request_guzzle.php';
}