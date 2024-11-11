<?php
/*
* This file handles the highscores for Snakesouls game
* It utilizes a mysql database to store the timestamp, playername and highscore
* It also has a Rest API that has end points for adding a new highscore and retrieving the top X highscores
*/
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

require_once('config.php');
require_once('class.snakesouls_highscores.php');

header('Content-Type: application/json');

$snakesouls_highscores = new snakesouls_highscores();
if($_SERVER['REQUEST_METHOD'] == 'GET') {
    //Handle request for data utilizing the snakesouls_highscore class
    $result = $snakesouls_highscores->get_highscores();
    echo json_encode($result);
}
elseif($_SERVER['REQUEST_METHOD'] == 'POST') {
    //Handle request for data saving utilizing the snakesouls_highscore class
    $data = file_get_contents('php://input');
    $data_decoded = urldecode($data);
    $hiscore_data = json_decode($data_decoded, true);
    $result = $snakesouls_highscores->add_highscore($hiscore_data);
    echo json_encode($result);
}


?>