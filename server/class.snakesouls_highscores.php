<?php
require_once('class.db_connect.php');
class snakesouls_highscores {
    function __construct() {

    }

    function add_highscore($data) {
        // Add new highscore
        $conn = db_connect::get_connection();
        
        $playername = htmlspecialchars(trim($data['playername']));
        $score = intval($data['score']);

        if($conn) {
            if($playername AND $score AND strlen($playername) > 0) {
                $sql_query = 'INSERT INTO snakesouls_highscores (playername, score) VALUES ("'.$playername.'",'.$score.');';
                if($result = $conn->query($sql_query)) {
                    $reply_array['status'] = 200;
                    $reply_array['message'] = "Saved $playername with score $score";
                }
                else {
                    $reply_array['status'] = 500;
                    $reply_array['message'] = $conn->error;
                }
            }
            else {
                $reply_array['status'] = 500;
                $reply_array['message'] = 'Parameters cannot be empty';
            }
        }
        else {
            $reply_array['status'] = 500;
            $reply_array['message'] = 'DB connection error';
        }
        return $reply_array;
    }

    function get_highscores() {
        // Get top X highscores
        // TODO: Implement limiting the number of scores by request, for now from defined hardcoded limit on server end
        $conn = db_connect::get_connection();
        
        $reply_array = array();

        if($conn) {
            $sql_query = 'SELECT playername, score FROM snakesouls_highscores ORDER BY score DESC LIMIT '.HIGHSCORE_LIMIT.';';

            if($result = $conn->query($sql_query)) {
                while($row=$result->fetch_assoc()) {
                    $reply_array['scores'][] = $row;
                }
                $reply_array['status'] = 200;
            }
            else {
                $reply_array['status'] = 500;
                $reply_array['message'] = $conn->error;
            }
        }
        else {
            $reply_array['status'] = 500;
            $reply_array['message'] = 'DB connection error';
        }

        return $reply_array;
    }
}
?>