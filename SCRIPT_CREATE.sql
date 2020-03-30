-- -----------------------------------------------------
-- Schema help_me_fest
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `help_me_fest` DEFAULT CHARACTER SET latin1 ;
USE `help_me_fest` ;

-- -----------------------------------------------------
-- Table `__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` VARCHAR(95) NOT NULL,
  `ProductVersion` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `departament`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `departament` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(30) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `profile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `profile` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(25) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `person` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `IsGuest` TINYINT(1) NOT NULL,
  `Discriminator` LONGTEXT CHARACTER SET 'utf8mb4' NOT NULL,
  `RelatedUserId` INT(11) NULL DEFAULT NULL,
  `Relantionship` VARCHAR(10) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `Email` VARCHAR(100) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `Password` VARCHAR(25) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `ProfileId` INT(11) NULL DEFAULT NULL,
  `DepartamentId` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK_Person_Departament_DepartamentId`
    FOREIGN KEY (`DepartamentId`)
    REFERENCES `departament` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Person_Person_RelatedUserId`
    FOREIGN KEY (`RelatedUserId`)
    REFERENCES `person` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Person_Profile_ProfileId`
    FOREIGN KEY (`ProfileId`)
    REFERENCES `profile` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `event` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `DateInitial` DATETIME(6) NOT NULL,
  `DateEnd` DATETIME(6) NOT NULL,
  `Description` VARCHAR(500) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `Place` VARCHAR(45) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `EventOrganizerId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK_Event_Person_EventOrganizerId`
    FOREIGN KEY (`EventOrganizerId`)
    REFERENCES `person` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `userevent`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `userevent` (
  `PersonId` INT(11) NOT NULL,
  `EventId` INT(11) NOT NULL,
  PRIMARY KEY (`PersonId`, `EventId`),
  CONSTRAINT `FK_UserEvent_Event_EventId`
    FOREIGN KEY (`EventId`)
    REFERENCES `event` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_UserEvent_Person_PersonId`
    FOREIGN KEY (`PersonId`)
    REFERENCES `person` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;
