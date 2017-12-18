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
-- Table structure for table `orderholders`
--

DROP TABLE IF EXISTS `orderholders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orderholders` (
  `PersonalIDNumber` varchar(36) NOT NULL,
  `Cash Account_USD` decimal(12,2) DEFAULT NULL,
  `Cash Account_EUR` decimal(12,2) DEFAULT NULL,
  `Cash Account_GBP` decimal(12,2) DEFAULT NULL,
  `Cash Account_SGD` decimal(12,2) DEFAULT NULL,
  `Cash Account_AUD` decimal(12,2) DEFAULT NULL,
  `Order` varchar(45) NOT NULL,
  `First Name` varchar(45) NOT NULL,
  `Last Name` varchar(45) NOT NULL,
  `Sex` varchar(45) NOT NULL,
  `Nationality` varchar(45) DEFAULT NULL,
  `Date of Birth` varchar(45) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `Mobile` varchar(45) NOT NULL,
  `Profession` varchar(45) DEFAULT NULL,
  `Person\Company` varchar(45) DEFAULT NULL,
  `Registered address` varchar(200) DEFAULT NULL,
  `Email` varchar(50) NOT NULL,
  `Adviser` varchar(100) DEFAULT NULL,
  `Date of Registration` varchar(45) DEFAULT NULL,
  `LogIN` varchar(45) DEFAULT NULL,
  `PassWORD` varchar(45) DEFAULT NULL,
  `Cash allocation` decimal(10,2) NOT NULL,
  `Company` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PersonalIDNumber`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  UNIQUE KEY `Order_UNIQUE` (`Order`),
  UNIQUE KEY `LogIN_UNIQUE` (`LogIN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderholders`
--

LOCK TABLES `orderholders` WRITE;
/*!40000 ALTER TABLE `orderholders` DISABLE KEYS */;
INSERT INTO `orderholders` VALUES ('10abd024-6251-11e7-8fb1-704d7b711c76',1000000.00,0.00,0.00,0.00,0.00,'q111','Ivan','Ivanovich','Male','rus','27.06.2017','NO','86786543211','CEO','Person','Dom u osera','abc@mail','111','2017-07-06 16:43:19','Ava@mail','698d51a19d8a121ce581499d7b701668',10000.00,'Castle Family','Issued'),('d4535c9d-672b-11e7-a5ff-00ff24bdc723',1000000.00,0.00,122.00,0.00,0.00,'q112','Alex','Peril','Male','rus','28.06.2017','NO','2345678988','CEO','Person','Dom 2','asd@mail','111','2017-07-12 20:59:21','asd@mail','5a30602013517e463c6d20d919aded11',10000.00,'Castle Family','Issued');
/*!40000 ALTER TABLE `orderholders` ENABLE KEYS */;
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
