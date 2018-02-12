-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: dbempresa
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `user` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  PRIMARY KEY (`user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES ('admin','123456');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `id_client` int(8) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `cognom1` varchar(50) NOT NULL,
  `cognom2` varchar(50) NOT NULL,
  `adreça` varchar(50) NOT NULL,
  `codi_postal` int(8) NOT NULL,
  `poblacio` varchar(50) NOT NULL,
  `provincia` varchar(50) NOT NULL,
  `telefon` int(16) NOT NULL,
  `fax` int(16) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=159 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (146,'David','Ramírez','Campoy','Mollet',80100,'Mollet','Barcelona',696969696,686868686,'a@aaa.a'),(147,'Aaron','Salvador','Marcos','Santako',80123,'Santako','Barcelona',612312323,612312323,'abc@abc.a'),(148,'Elvis','Canario','Farray','Malasaña',90909,'Madriz','Madril',623432234,623432234,'bbc@bbc.a'),(149,'David','Ramírez','Campoy','Mollet',0,'Mollet','Barcelona',696969696,686868686,'a@aaa.a'),(150,'Aaron','Salvador','Marcos','Santako',80123,'Santako','Barcelona',612312323,612312323,'abc@abc.a'),(151,'Elvis','Canario','Farray','Malasaña',90909,'Madriz','Madril',623432234,623432234,'bbc@bbc.a'),(152,'David','Ramírez','Campoy','Mollet',80100,'Mollet','Barcelona',696969696,686868686,'a@aaa.a'),(153,'Aaron','Salvador','Marcos','Santako',80123,'Santako','Barcelona',612312323,612312323,'abc@abc.a'),(154,'Elvis','Canario','Farray','Malasaña',90909,'Madriz','Madril',623432234,623432234,'bbc@bbc.a'),(155,'David','Ramírez','Campoy','Mollet',80100,'Mollet','Barcelona',696969696,686868686,'a@aaa.a'),(156,'Aaron','Salvador','Marcos','Santako',80123,'Santako','Barcelona',612312323,612312323,'abc@abc.a'),(157,'Elvis','Canario','Farray','Malasaña',90909,'Madriz','Madril',623432234,623432234,'bbc@bbc.a'),(158,'Nou ','Client','Demo','aasd',123,'a','a',123,123,'a');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factura` (
  `n_factura` int(8) NOT NULL AUTO_INCREMENT,
  `id_client` int(8) NOT NULL,
  `data` datetime DEFAULT NULL,
  `descompte` int(8) DEFAULT NULL,
  `iva` int(8) DEFAULT NULL,
  PRIMARY KEY (`n_factura`),
  KEY `fk_id_client` (`id_client`),
  CONSTRAINT `fk_id_client` FOREIGN KEY (`id_client`) REFERENCES `clients` (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
INSERT INTO `factura` VALUES (26,146,'2017-12-05 00:10:00',15,21),(27,146,'2017-12-26 00:10:00',20,21),(28,147,'2017-12-28 00:10:00',9,21),(29,148,'2017-12-29 00:10:00',10,21),(30,149,'2017-12-05 00:10:00',15,21),(31,149,'2017-12-26 00:10:00',20,21),(32,150,'2017-12-28 00:10:00',9,21),(33,151,'2017-12-29 00:10:00',10,21),(34,152,'2017-12-05 00:10:00',15,21),(35,152,'2017-12-26 00:10:00',20,21),(36,153,'2017-12-28 00:10:00',9,21),(37,154,'2017-12-29 00:10:00',10,21),(38,155,'2017-12-05 00:10:00',15,21),(39,155,'2017-12-26 00:10:00',20,21),(40,156,'2017-12-28 00:10:00',9,21),(41,157,'2017-12-29 00:10:00',10,21);
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_detall`
--

DROP TABLE IF EXISTS `factura_detall`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factura_detall` (
  `id_factura_detall` int(8) NOT NULL AUTO_INCREMENT,
  `n_factura` int(8) DEFAULT NULL,
  `id_producte` int(8) DEFAULT NULL,
  `quantitat` int(8) DEFAULT NULL,
  PRIMARY KEY (`id_factura_detall`),
  KEY `fk_producte` (`id_producte`),
  KEY `fk_n_factura` (`n_factura`),
  CONSTRAINT `fk_n_factura` FOREIGN KEY (`n_factura`) REFERENCES `factura` (`n_factura`),
  CONSTRAINT `fk_producte` FOREIGN KEY (`id_producte`) REFERENCES `productes` (`id_produte`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_detall`
--

LOCK TABLES `factura_detall` WRITE;
/*!40000 ALTER TABLE `factura_detall` DISABLE KEYS */;
INSERT INTO `factura_detall` VALUES (17,26,24,10),(18,27,25,11),(19,28,26,15),(20,29,27,1),(21,30,28,10),(22,31,29,11),(23,32,30,15),(24,33,31,1),(25,34,32,10),(26,35,33,11),(27,36,34,15),(28,37,35,1),(29,38,36,10),(30,39,37,11),(31,40,38,15),(32,41,39,1),(33,41,39,1);
/*!40000 ALTER TABLE `factura_detall` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productes`
--

DROP TABLE IF EXISTS `productes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productes` (
  `id_produte` int(8) NOT NULL AUTO_INCREMENT,
  `producte` varchar(50) NOT NULL,
  `preu` decimal(5,2) NOT NULL,
  PRIMARY KEY (`id_produte`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productes`
--

LOCK TABLES `productes` WRITE;
/*!40000 ALTER TABLE `productes` DISABLE KEYS */;
INSERT INTO `productes` VALUES (24,'Lasers',191.00),(25,'Pistolas',19.00),(26,'Peluca',50.00),(27,'Disfraz',30.00),(28,'Lasers',191.00),(29,'Pistolas',19.00),(30,'Peluca',50.00),(31,'Disfraz',30.00),(32,'Lasers',191.00),(33,'Pistolas',19.00),(34,'Peluca',50.00),(35,'Disfraz',30.00),(36,'Lasers',191.00),(37,'Pistolas',19.00),(38,'Peluca',50.00),(39,'Disfraz',30.00);
/*!40000 ALTER TABLE `productes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-12 18:13:57
