-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: custodian
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `risktest`
--

DROP TABLE IF EXISTS `risktest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `risktest` (
  `OrderKlient` varchar(45) NOT NULL,
  `TestResult` int(1) NOT NULL,
  `DateTest` date NOT NULL,
  `QR1` varchar(45) DEFAULT NULL,
  `QR2` varchar(45) DEFAULT NULL,
  `QR3` varchar(45) DEFAULT NULL,
  `QR4` varchar(45) DEFAULT NULL,
  `QR5` varchar(45) DEFAULT NULL,
  `QR6` varchar(45) DEFAULT NULL,
  `QR7` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `risktest`
--

LOCK TABLES `risktest` WRITE;
/*!40000 ALTER TABLE `risktest` DISABLE KEYS */;
INSERT INTO `risktest` VALUES ('q111',4,'2017-07-14','4','6','4','4','3','3','4'),('q111',4,'2017-07-14','6','6','6','4','1','0','3'),('q111',4,'2017-07-14','6','6','6','4','1','0','6'),('q111',6,'2017-07-14','6','6','6','4','6','6','6'),('q111',0,'2017-07-17','0','0','0','0','0','0','0');
/*!40000 ALTER TABLE `risktest` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-17 12:38:06
