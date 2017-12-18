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
-- Table structure for table `activesb`
--

DROP TABLE IF EXISTS `activesb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `activesb` (
  `IDActive` varchar(36) NOT NULL,
  `OrderNumber` varchar(45) NOT NULL,
  `PaperType` varchar(45) NOT NULL,
  `Isin` varchar(45) NOT NULL,
  `Value` varchar(45) NOT NULL,
  `Money` decimal(10,2) NOT NULL,
  `CountPaper` decimal(10,2) NOT NULL,
  `AqPrice` decimal(10,2) NOT NULL,
  `valueAqPrice` varchar(45) DEFAULT NULL,
  `DateGetInstruction` varchar(45) NOT NULL,
  `DateRegistInstruction` varchar(45) NOT NULL,
  `AdminGegistr` varchar(45) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `NumberOperation` int(11) NOT NULL,
  `DocumentInst` varchar(36) NOT NULL,
  PRIMARY KEY (`IDActive`),
  UNIQUE KEY `IDActive_UNIQUE` (`IDActive`),
  KEY `idx_activesb_OrderNumber` (`OrderNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activesb`
--

LOCK TABLES `activesb` WRITE;
/*!40000 ALTER TABLE `activesb` DISABLE KEYS */;
/*!40000 ALTER TABLE `activesb` ENABLE KEYS */;
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
