CREATE TABLE `nasaportal`.`pictureoftheday` (
  `Id` CHAR(36) NOT NULL,
  `Copyight` VARCHAR(200) NOT NULL,
  `PictureDate` DATETIME NOT NULL,
  `Explanation` VARCHAR(1000) NOT NULL,
  `HdUrl` VARCHAR(5000) NOT NULL,
  `Title` VARCHAR(200) NOT NULL,
  `Url` VARCHAR(5000) NOT NULL,
  PRIMARY KEY (`Id`));
