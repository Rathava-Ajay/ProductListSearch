-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.6.48-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for demosearch
CREATE DATABASE IF NOT EXISTS `demosearch` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `demosearch`;

-- Dumping structure for procedure demosearch.SearchProducts
DELIMITER //
CREATE PROCEDURE `SearchProducts`(
	IN `sProductName` VARCHAR(50),
	IN `sSize` VARCHAR(50),
	IN `sCategory` VARCHAR(50)
)
    SQL SECURITY INVOKER
BEGIN
    SET @QUERY = 'SELECT * FROM products WHERE 1=1';

    IF COALESCE(sProductName, '') <> '' THEN
        SET @QUERY = CONCAT(@QUERY, " AND ProductName = '", sProductName, "'");
    END IF;

    IF COALESCE(sSize, '') <> '' THEN
        SET @QUERY = CONCAT(@QUERY, " OR Size = '", sSize, "'");
    END IF;

    IF COALESCE(sCategory, '') <> '' THEN
        SET @QUERY = CONCAT(@QUERY, " OR Category = '", sCategory, "'");
    END IF;

    PREPARE STMT FROM @QUERY;
    EXECUTE STMT;
    DEALLOCATE PREPARE STMT;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
