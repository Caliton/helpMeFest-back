-- -----------------------------------------------------
-- Schema help_me_fest
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `help_me_fest` DEFAULT CHARACTER SET latin1 ;
USE `help_me_fest` ;

-- -----------------------------------------------------
-- Table `help_me_fest`.`__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`__efmigrationshistory` (
  `MigrationId` VARCHAR(95) NOT NULL,
  `ProductVersion` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `help_me_fest`.`departament`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`departament` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(30) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `help_me_fest`.`profile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`profile` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(25) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `help_me_fest`.`person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`person` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(25) CHARACTER SET 'utf8mb4' NOT NULL,
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
    REFERENCES `help_me_fest`.`departament` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Person_Person_RelatedUserId`
    FOREIGN KEY (`RelatedUserId`)
    REFERENCES `help_me_fest`.`person` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Person_Profile_ProfileId`
    FOREIGN KEY (`ProfileId`)
    REFERENCES `help_me_fest`.`profile` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `help_me_fest`.`event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`event` (
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
    REFERENCES `help_me_fest`.`person` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `help_me_fest`.`userevent`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `help_me_fest`.`userevent` (
  `IdUser` INT(11) NOT NULL,
  `IdEvent` INT(11) NOT NULL,
  `UserId` INT(11) NULL DEFAULT NULL,
  `EvetId` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`IdUser`, `IdEvent`),
  CONSTRAINT `FK_UserEvent_Event_EvetId`
    FOREIGN KEY (`EvetId`)
    REFERENCES `help_me_fest`.`event` (`Id`),
  CONSTRAINT `FK_UserEvent_Person_UserId`
    FOREIGN KEY (`UserId`)
    REFERENCES `help_me_fest`.`person` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;
