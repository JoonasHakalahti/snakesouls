<?php
/*
* This file governs some defined constants for us to utilize such as databse connection stuff
*/ 
define('ENVIRONMENT', 'niisku'); //options are test and niisku

if(ENVIRONMENT == 'test') {
    define('SERVER', "127.0.0.1");
    define('DB_USER', "root");
    define('DB_PASS', ""); //TODO: Make this a safe setup with not a clear coded password visible
    define('DB_NAME', "snakesouls");
}
elseif (ENVIRONMENT == 'niisku'){
    define('SERVER', "127.0.0.1");
    define('DB_USER', "x116736");
    define('DB_PASS', "Koodaus1"); //TODO: Make this a safe setup with not a clear coded password visible
    define('DB_NAME', "user_x116736");
}


define('HIGHSCORE_LIMIT', 3); // This is temporary definition and will be modified to be part of the datarequest if we have time
?>