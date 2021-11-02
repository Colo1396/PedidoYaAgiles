-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema buuj9zpj3u0cpsih8ypu
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema buuj9zpj3u0cpsih8ypu
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `buuj9zpj3u0cpsih8ypu` DEFAULT CHARACTER SET utf8 ;
USE `buuj9zpj3u0cpsih8ypu` ;

-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`categoria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`categoria` (
  `idCategoria` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idCategoria`))
ENGINE = InnoDB
AUTO_INCREMENT = 20
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`usuario` (
  `username` VARCHAR(100) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`comercio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`comercio` (
  `idComercio` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(255) NULL DEFAULT NULL,
  `direccion` VARCHAR(255) NULL DEFAULT NULL,
  `localidad` VARCHAR(255) NULL DEFAULT NULL,
  `telefono` VARCHAR(255) NULL DEFAULT NULL,
  `calificacion` DOUBLE NULL DEFAULT NULL,
  `logo` VARCHAR(255) NULL DEFAULT NULL,
  `idUsuario` BIGINT NULL DEFAULT NULL,
  `descripcion` VARCHAR(100) NULL DEFAULT NULL,
  `costoEnvio` DOUBLE NULL DEFAULT NULL,
  `horario` VARCHAR(45) NULL DEFAULT NULL,
  `diasAbierto` VARCHAR(45) NULL DEFAULT NULL,
  `promCalificacion` DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (`idComercio`),
  INDEX `comercio_FK` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `comercio_FK`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `buuj9zpj3u0cpsih8ypu`.`usuario` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 40
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`comercioxcategoria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`comercioxcategoria` (
  `idCategoria` INT NOT NULL,
  `idComercio` INT NOT NULL,
  PRIMARY KEY (`idCategoria`, `idComercio`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`localidad`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`localidad` (
  `idLocalidad` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`idLocalidad`))
ENGINE = InnoDB
AUTO_INCREMENT = 27
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`pedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`pedido` (
  `idPedido` INT NOT NULL AUTO_INCREMENT,
  `idComercio` INT NOT NULL,
  `descripcion` VARCHAR(1500) NULL DEFAULT NULL,
  `direccion` VARCHAR(255) NULL DEFAULT NULL,
  `comentarios` VARCHAR(255) NULL DEFAULT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  `calificacion` INT NULL DEFAULT NULL,
  `fechaHoraPedido` DATETIME NULL DEFAULT NULL,
  `opinion` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`idPedido`),
  INDEX `fk_pedido_comercio1_idx` (`idComercio` ASC) VISIBLE,
  CONSTRAINT `fk_pedido_comercio1`
    FOREIGN KEY (`idComercio`)
    REFERENCES `buuj9zpj3u0cpsih8ypu`.`comercio` (`idComercio`))
ENGINE = InnoDB
AUTO_INCREMENT = 74
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `buuj9zpj3u0cpsih8ypu`.`producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buuj9zpj3u0cpsih8ypu`.`producto` (
  `idProducto` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(255) NULL DEFAULT NULL,
  `descripcion` VARCHAR(255) NULL DEFAULT NULL,
  `foto` VARCHAR(255) NULL DEFAULT NULL,
  `precio` DOUBLE NULL DEFAULT NULL,
  `visible` BIT(1) NULL DEFAULT NULL,
  `idComercio` INT NOT NULL,
  PRIMARY KEY (`idProducto`, `idComercio`),
  INDEX `fk_producto_comercio1_idx` (`idComercio` ASC) VISIBLE,
  CONSTRAINT `fk_producto_comercio1`
    FOREIGN KEY (`idComercio`)
    REFERENCES `buuj9zpj3u0cpsih8ypu`.`comercio` (`idComercio`))
ENGINE = InnoDB
AUTO_INCREMENT = 97
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
