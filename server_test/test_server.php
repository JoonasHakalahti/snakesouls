<?php
/*
* This file runs a series of tests to verify the Snakesouls backend server is functioning
*/

define('ENVIRONMENT', 'test'); //options are test and niisku
if(ENVIRONMENT == 'test') define('BASE_URL', '127.0.0.1/snakesouls/server/');
else define('BASE_URL', 'https://niisku.lab.fi/~x116736/snakesouls/');

define('SERVER_URL', BASE_URL.'server.php');


// Function to test GET request
function testGetRequest($url) {
    echo "Testing GET request...\n";
    $response = file_get_contents($url);

    if ($response === FALSE) {
        echo "GET request failed.\n";
    } else {
        echo "GET request successful. Response:\n";
        echo $response;
    }
}

// Function to test POST request
function testPostRequest($url) {
    echo "Testing POST request...\n";

    $data = array(
        'playername' => 'TestPlayer',
        'score' => 12345
    );

    $options = array(
        'http' => array(
            'header'  => "Content-Type: application/json\r\n",
            'method'  => 'POST',
            'content' => json_encode($data),
        ),
    );

    $context  = stream_context_create($options);
    $response = file_get_contents($url, false, $context);

    if ($response === FALSE) {
        echo "POST request failed.\n";
    } else {
        echo "POST request successful. Response:\n";
        echo $response;
    }
}

// Run tests
testGetRequest(SERVER_URL);
echo "\n";
testPostRequest(SERVER_URL);


?>