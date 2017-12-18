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
-- Table structure for table `tasks_documents`
--

DROP TABLE IF EXISTS `tasks_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tasks_documents` (
  `Number_task` varchar(36) NOT NULL,
  `Document_Name` varchar(100) NOT NULL,
  `path_ftp` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks_documents`
--

LOCK TABLES `tasks_documents` WRITE;
/*!40000 ALTER TABLE `tasks_documents` DISABLE KEYS */;
INSERT INTO `tasks_documents` VALUES ('e0113285-0459-411b-bec2-e212863a2926','|q111_main_user_task_№_2','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_2'),('3f43fb45-9a83-4a0c-aca3-61f9523d66a4','|q111_main_user_task_№_3','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_3'),('daeb3c47-433b-415c-9e9d-396e4637730e','|q111_main_user_task_№_4','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_4'),('21353930-9bd7-4812-b855-7dd44a5813be','|q111_main_user_task_№_5','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_5'),('488a8270-5683-4953-942e-51c92988b21e','|q111_main_user_task_№_6','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_6'),('cecd2380-98bc-422d-a14a-7a0196967a44','|q111_main_user_task_№_7','ftp://ftp.castlefamily.co.uk//q111//|q111_main_user_task_№_7');
/*!40000 ALTER TABLE `tasks_documents` ENABLE KEYS */;
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
