CREATE DATABASE  IF NOT EXISTS `nasaportal` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `nasaportal`;

GRANT ALL PRIVILEGES ON nasaportal.* TO 'my_database_username'@'%';
FLUSH PRIVILEGES;

CREATE TABLE `nasaportal`.`pictureoftheday` (
  `Id` CHAR(36) NOT NULL,
  `Copyright` VARCHAR(200) NOT NULL,
  `PictureDate` DATETIME NOT NULL,
  `Explanation` VARCHAR(1000) NOT NULL,
  `HdUrl` VARCHAR(5000) NOT NULL,
  `Title` VARCHAR(200) NOT NULL,
  `Url` VARCHAR(5000) NOT NULL,
  PRIMARY KEY (`Id`));


insert into pictureoftheday values ('b31d2c8c-bdab-4b1e-943f-dcd0e55cf667', 'Wang Letian', '2024-02-17', 'A cosmic dust grain plowing through the upper', 'https://apod.nasa.gov/apod/image/2402/MeteorBayofNaples_V2.jpg', 'Meteor over the Bay of Naples', 'https://apod.nasa.gov/apod/image/2402/MeteorBayofNaples_V2_1024.jpg')