This server handles the backend score keeping for Snakesouls game from Team 13.

For setting up the new backend, make sure to run the setup_database.sql which will first drop existing highscores table and then create a new one.

config.php manages all of the general constants required such as database credentials and are we working in test (localhost) or niisku

server.php manages the incoming REST API requests and handles the queries utilizing the various classes

Endpoints
GET = returns the TOP X highscores. Number of results defined in server config
POST = expects playername and score as an integer in JSON format

Server always replies with status and message
200 = OK, may not contain a message
500 = Error, contains message tellign the error