<?php
class db_connect{

    private static $instance;
    private $connection;

    private function __construct(){
        //make your db connnection
        $this->connection = new mysqli(SERVER, DB_USER, DB_PASS, DB_NAME);
        //Check connection
        if($this->connection->connect_error) {
            die('Connection failed!'.$this->connection->connect_error);
        }
    }

    public static function get_connection() {
        if (empty(self::$instance)) {
            self::$instance = new db_connect();
        }
        return self::$instance->connection; // Return the connection instance
    }

    public static function close_connection() {
        if (self::$instance && self::$instance->connection) {
            self::$instance->connection->close();
            self::$instance = null; // Reset the instance after closing
        }
    }
}
?>