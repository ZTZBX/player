CREATE TABLE IF NOT EXISTS playerstats (
    username varchar(50) NOT NULL,
    configured tinyint NOT NULL DEFAULT 0, -- check if the player has conf and if not trigger a midlleware
    hoursplayed int NOT NULL DEFAULT 0, 
    gender CHAR NOT NULL DEFAULT "M",
    FOREIGN KEY (username) REFERENCES players(username),
    PRIMARY KEY(username)
)ENGINE=InnoDB;


CREATE TABLE IF NOT EXISTS playerface (
    username varchar(50) NOT NULL,
    facecomponent int not null,
    componentvariation int not null,
    FOREIGN KEY (username) REFERENCES players(username)
)ENGINE=InnoDB;


CREATE TABLE IF NOT EXISTS playerbody (
    username varchar(50) NOT NULL,
    skincolor int not null,
    bodytype int not null,
    FOREIGN KEY (username) REFERENCES players(username),
    PRIMARY KEY(username)
)ENGINE=InnoDB;


CREATE TABLE IF NOT EXISTS itemscharternametoid (
    `id` int NOT NULL, -- id_on is describe the part of the body the item is puted
    `name` varchar(50) NOT NULL,
    UNIQUE KEY(`name`),
    PRIMARY KEY(`id`)
)ENGINE=InnoDB;


CREATE TABLE IF NOT EXISTS itemsoncharters (
    username varchar(50) NOT NULL,
    `idbodypart` int NOT NULL, -- id_on is describe the part of the body the item is puted
    `name` varchar(50) NOT NULL,
    FOREIGN KEY (`name`) REFERENCES itemsmetadata(`name`),
    FOREIGN KEY (`idbodypart`) REFERENCES itemscharternametoid(`id`),
    FOREIGN KEY (username) REFERENCES players(username),
    UNIQUE KEY `unique_player_item` (`username`,`name`),
    UNIQUE KEY `unique_player_item_on_player_body` (`idbodypart`, `name`)
)ENGINE=InnoDB;

-- INSERTS 

INSERT INTO `itemscharternametoid` (`id`, `name`) VALUES ('6', 'Shoes');