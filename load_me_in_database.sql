CREATE TABLE IF NOT EXISTS playerstats (
    username varchar(50) NOT NULL,
    configured tinyint NOT NULL DEFAULT 0, -- check if the player has conf and if not trigger a midlleware
    hoursplayed int NOT NULL DEFAULT 0, 
    gender CHAR NOT NULL DEFAULT "M",
    FOREIGN KEY (username) REFERENCES players(username),
    PRIMARY KEY(username)
)ENGINE=InnoDB;


CREATE TABLE IF NOT EXISTS playeraspect (
    username varchar(50) NOT NULL,
    blackrange FLOAT NOT NULL,
    nosewidththinwide FLOAT NOT NULL,
    nosepeakupdown FLOAT NOT NULL,
    noselengthlongshort FLOAT NOT NULL,
    newosebonecurvenesscrookedcurved FLOAT NOT NULL,
    nosetipupdown FLOAT NOT NULL,
    nosebonetwistleftright FLOAT NOT NULL,
    eyebrowupdown FLOAT NOT NULL,
    eyebrowinout FLOAT NOT NULL,
    cheekbonesupdown FLOAT NOT NULL,
    cheeksidewaysboneaizeinout FLOAT NOT NULL,
    cheekboneswidthpuffedgaunt FLOAT NOT NULL,
    eyeopeningbothwidesquinted FLOAT NOT NULL,
    lipthicknessbothfatthin FLOAT NOT NULL,
    jawbonewidthnarrowWide FLOAT NOT NULL,
    jawboneshaperoundsquare FLOAT NOT NULL,
    chinboneupdown FLOAT NOT NULL,
    chinbonelengthinout FLOAT NOT NULL,
    chinboneshapepointedsquare FLOAT NOT NULL,
    chinholechinbum FLOAT NOT NULL,
    neckthicknessthinthick FLOAT NOT NULL,
    eyes INT NOT NULL,
    hair INT NOT NULL,
    haircolor INT NOT NULL,
    hairhightlight INT NOT NULL,
    facialhair INT NOT NULL,
    eyebrows INT NOT NULL,
    makeup INT NOT NULL,
    lipstick INT NOT NULL,
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
    UNIQUE KEY `unique_player_item_on_player_body` (`idbodypart`, `name`, `username`)
)ENGINE=InnoDB;


-- INSERTS 
INSERT INTO `itemscharternametoid` (`id`, `name`) VALUES ('6', 'Shoes');
INSERT INTO `itemscharternametoid` (`id`, `name`) VALUES ('4', 'Pants');