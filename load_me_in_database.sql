CREATE TABLE itemscharternametoid (
    `id` int NOT NULL, -- id_on is describe the part of the body the item is puted
    `name` varchar(50) NOT NULL,
    UNIQUE KEY(`name`),
    PRIMARY KEY(`id`)
)ENGINE=InnoDB;

INSERT INTO `itemscharternametoid` (`id`, `name`) VALUES ('6', 'Shoes');

CREATE TABLE itemsoncharters (
    username varchar(50) NOT NULL,
    `idbodypart` int NOT NULL, -- id_on is describe the part of the body the item is puted
    `name` varchar(50) NOT NULL,
    FOREIGN KEY (`name`) REFERENCES itemsmetadata(`name`),
    FOREIGN KEY (`idbodypart`) REFERENCES itemscharternametoid(`id`),
    FOREIGN KEY (username) REFERENCES players(username),
    UNIQUE KEY `unique_player_item` (`username`,`name`),
    UNIQUE KEY `unique_player_item_on_player_body` (`idbodypart`, `name`)
)ENGINE=InnoDB;