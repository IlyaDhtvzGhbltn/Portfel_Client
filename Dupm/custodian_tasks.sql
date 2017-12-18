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
-- Table structure for table `tasks`
--

DROP TABLE IF EXISTS `tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tasks` (
  `NumberTasks_id` varchar(36) NOT NULL,
  `ClientOrder` varchar(45) NOT NULL,
  `Admin_managerID` varchar(45) NOT NULL,
  `DataIn` datetime NOT NULL,
  `DataOut` datetime DEFAULT NULL,
  `Status` varchar(45) NOT NULL,
  PRIMARY KEY (`NumberTasks_id`),
  UNIQUE KEY `NumberTasks_id_UNIQUE` (`NumberTasks_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks`
--

LOCK TABLES `tasks` WRITE;
/*!40000 ALTER TABLE `tasks` DISABLE KEYS */;
INSERT INTO `tasks` VALUES ('21353930-9bd7-4812-b855-7dd44a5813be','q111','111','2017-07-11 11:33:25',NULL,'Received'),('3f43fb45-9a83-4a0c-aca3-61f9523d66a4','q111','111','2017-07-11 11:27:45',NULL,'Received'),('488a8270-5683-4953-942e-51c92988b21e','q111','111','2017-07-11 11:49:34',NULL,'Received'),('cecd2380-98bc-422d-a14a-7a0196967a44','q111','111','2017-07-11 11:49:45',NULL,'Received'),('daeb3c47-433b-415c-9e9d-396e4637730e','q111','111','2017-07-11 11:30:35',NULL,'Received'),('dc9460b4-2eb6-4757-b4f9-104ac4f56f01','q111','111','2017-07-10 18:38:33','2017-07-11 00:34:24','Closed'),('e0113285-0459-411b-bec2-e212863a2926','q111','111','2017-07-11 11:24:53',NULL,'Received');
/*!40000 ALTER TABLE `tasks` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-17 12:38:05
