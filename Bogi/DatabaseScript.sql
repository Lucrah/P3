-- MySQL Script generated by MySQL Workbench
-- 11/09/15 11:59:20
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema p3database
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema p3database
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `p3database` DEFAULT CHARACTER SET utf8 ;
USE `p3database` ;

-- -----------------------------------------------------
-- Table `p3database`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `p3database`.`address` (
  `IDAddress` INT(11) NOT NULL,
  `StreetName` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `HouseNumber` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `AreaCode` INT(11) NULL DEFAULT NULL,
  `Lat` DECIMAL(20,15) NULL DEFAULT NULL,
  `Lng` DECIMAL(20,15) NULL DEFAULT NULL,
  PRIMARY KEY (`IDAddress`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `p3database`.`salesinfo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `p3database`.`salesinfo` (
  `IDSalesInfo` INT(11) NOT NULL,
  `SalesType` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `Price` INT(11) NULL DEFAULT NULL,
  `PriceSqr` INT(11) NULL DEFAULT NULL,
  `SalesDate` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`IDSalesInfo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `p3database`.`listings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `p3database`.`listings` (
  `IDListings` INT(11) NOT NULL,
  `PropertyType` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `Size` INT(11) NULL DEFAULT NULL,
  `NumberOfRooms` INT(11) NULL DEFAULT NULL,
  `YearBuild` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`IDListings`),
  CONSTRAINT `Address`
    FOREIGN KEY (`IDListings`)
    REFERENCES `p3database`.`address` (`IDAddress`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SalesInfo`
    FOREIGN KEY (`IDListings`)
    REFERENCES `p3database`.`salesinfo` (`IDSalesInfo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
