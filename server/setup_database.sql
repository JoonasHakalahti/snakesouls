USE user_x116736;

DROP TABLE IF EXISTS snakesouls_highscores;

CREATE TABLE `snakesouls_highscores` (
    `id` INT(11) NOT NULL AUTO_INCREMENT, 
    `playername` VARCHAR(255) NOT NULL , 
    `score` INT(11) NOT NULL , 
    `timestamp` DATETIME DEFAULT CURRENT_TIMESTAMP , 
    PRIMARY KEY (`id`), INDEX `score` (`score`)) 
    ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;