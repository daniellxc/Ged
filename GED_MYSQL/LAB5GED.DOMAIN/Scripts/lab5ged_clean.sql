-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: lab5_ged
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tb_acao`
--

DROP TABLE IF EXISTS `tb_acao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_acao` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `nome_acao` varchar(100) NOT NULL,
  `descricao_acao` varchar(255) NOT NULL,
  PRIMARY KEY (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_acao`
--

LOCK TABLES `tb_acao` WRITE;
/*!40000 ALTER TABLE `tb_acao` DISABLE KEYS */;
INSERT INTO `tb_acao` VALUES (1,'Controlar Ação','Acesso ao controle de a??es do sistema.'),(2,'Excluir Documento','Permiss?o para excluir definitivamente documentos do sistema.'),(3,'Controlar Grupo','Acesso ao controle de grupos de usu?rios do sistema.'),(4,'Controlar Permissão','Acesso ao controle de permiss?es do sistema.'),(19,'Controlar Prazo de Guarda','Acesso ao controle de prazos de guarda do sistema.'),(20,'Controlar Série','Acesso ao controle de s?ries do sistema.'),(21,'Controlar Subclasse','Acesso ao controle de subclasses do sistema.'),(22,'Controlar Subsérie','Acesso ao controle de subs?ries do sistema.'),(23,'Controlar Indexadores','Acesso ao controle de indexadores do sistema.'),(24,'Indexação','Realizar indexa??o dos documentos. A??o de informar o valor ? um indexador existente.'),(25,'Controlar Usuário','Acesso ao controle de usu?rio do sistema.'),(26,'Alterar Senha','Alterar senha do usu?rio.'),(27,'Controlar Classe','Acesso ao controle de classes do sistema.'),(28,'Listar Todos Documentos','Listagem de todos os documentos cadastrados no sistema.'),(29,'Cadastrar Documento','Cadastro de documentos no sistema.'),(30,'Listar Documentos Não Revisados','Listagem de todos documentos que n?o foram revisados.'),(31,'Armazenar Documento','Registrar localiza??o f?sica de um documento.'),(32,'Revisão','Revis?o de documentos'),(33,'Controlar Corredor','Acesso ao controle de corredores.'),(34,'Controlar Estante','Acesso ao controle de estantes.'),(35,'Controlar Prateleira','Acesso ao controle de prateleiras.'),(36,'Editar Indexação','Editar valores de uma indexa??o realizada.'),(37,'Iniciar Revisão','Inicia o processo de confer?ncia de documentos.'),(38,'Consulta Detalhada','Consulta de documentos por índice.'),(39,'Controlar Subserie Usuario','Adicionar ou remover as subséries que o usuário poderá manipular.'),(40,'Visualizar Subserie Usuario','Abre a tela para configurar as subséries que o usuário poderá manipular.');
/*!40000 ALTER TABLE `tb_acao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_acao_grupo`
--

DROP TABLE IF EXISTS `tb_acao_grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_acao_grupo` (
  `ACAO` int(11) NOT NULL,
  `GRUPO` int(11) NOT NULL,
  PRIMARY KEY (`ACAO`,`GRUPO`),
  KEY `fk_grupo_idx` (`GRUPO`),
  CONSTRAINT `fk_acao` FOREIGN KEY (`ACAO`) REFERENCES `tb_acao` (`registro`),
  CONSTRAINT `fk_grupo` FOREIGN KEY (`GRUPO`) REFERENCES `tb_grupo` (`registro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_acao_grupo`
--

LOCK TABLES `tb_acao_grupo` WRITE;
/*!40000 ALTER TABLE `tb_acao_grupo` DISABLE KEYS */;
INSERT INTO `tb_acao_grupo` VALUES (1,1),(2,1),(3,1),(4,1),(19,1),(20,1),(21,1),(22,1),(23,1),(24,1),(25,1),(26,1),(27,1),(28,1),(29,1),(30,1),(31,1),(32,1),(33,1),(34,1),(35,1),(36,1),(37,1),(38,1),(39,1),(40,1),(24,2),(29,2),(30,2),(31,2),(32,2),(37,2),(38,2);
/*!40000 ALTER TABLE `tb_acao_grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_caixa`
--

DROP TABLE IF EXISTS `tb_caixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_caixa` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `id_caixa` varchar(100) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `PRATELEIRA` int(11) NOT NULL,
  `SUBSERIE` int(11) NOT NULL,
  `aberta` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `id_caixa_UNIQUE` (`id_caixa`),
  KEY `FK_Prateleira_idx` (`PRATELEIRA`),
  KEY `FK_Subserie_idx` (`SUBSERIE`),
  CONSTRAINT `FK_Prateleira` FOREIGN KEY (`PRATELEIRA`) REFERENCES `tb_prateleira` (`registro`),
  CONSTRAINT `FK_SubserieCaixa` FOREIGN KEY (`SUBSERIE`) REFERENCES `tb_subserie` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_caixa`
--

LOCK TABLES `tb_caixa` WRITE;
/*!40000 ALTER TABLE `tb_caixa` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_caixa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_classe`
--

DROP TABLE IF EXISTS `tb_classe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_classe` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `id_classe` char(3) NOT NULL,
  `rotulo_classe` varchar(255) NOT NULL,
  `ativo` bit(1) NOT NULL,
  `data_abertura` datetime NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `id_classe_UNIQUE` (`id_classe`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_classe`
--

LOCK TABLES `tb_classe` WRITE;
/*!40000 ALTER TABLE `tb_classe` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_classe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_corredor`
--

DROP TABLE IF EXISTS `tb_corredor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_corredor` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_corredor`
--

LOCK TABLES `tb_corredor` WRITE;
/*!40000 ALTER TABLE `tb_corredor` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_corredor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_documento`
--

DROP TABLE IF EXISTS `tb_documento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_documento` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `SUBSERIE` int(11) NOT NULL,
  `data_criacao` datetime NOT NULL,
  `CAIXA` int(11) DEFAULT NULL,
  `descricao` varchar(255) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_subseriedocumento_idx` (`SUBSERIE`),
  KEY `fk_caixa_idx` (`CAIXA`),
  CONSTRAINT `fk_caixa` FOREIGN KEY (`CAIXA`) REFERENCES `tb_caixa` (`registro`),
  CONSTRAINT `fk_subseriedocumento` FOREIGN KEY (`SUBSERIE`) REFERENCES `tb_subserie` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_documento`
--

LOCK TABLES `tb_documento` WRITE;
/*!40000 ALTER TABLE `tb_documento` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_documento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_documento_digitalizacao`
--

DROP TABLE IF EXISTS `tb_documento_digitalizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_documento_digitalizacao` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) DEFAULT NULL,
  `dados` mediumblob NOT NULL,
  `extensao` varchar(10) NOT NULL,
  `DOCUMENTO` int(11) NOT NULL,
  `observacao` text,
  `ordem` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_doc_digitalizado_documento_idx` (`DOCUMENTO`),
  CONSTRAINT `fk_doc_digitalizado_documento` FOREIGN KEY (`DOCUMENTO`) REFERENCES `tb_documento` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_documento_digitalizacao`
--

LOCK TABLES `tb_documento_digitalizacao` WRITE;
/*!40000 ALTER TABLE `tb_documento_digitalizacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_documento_digitalizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_documento_manipulacao`
--

DROP TABLE IF EXISTS `tb_documento_manipulacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_documento_manipulacao` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `DOCUMENTO` int(11) NOT NULL,
  `TIPO_MANIPULACAO` int(11) NOT NULL,
  `USUARIO` int(11) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_manipulacao_idx` (`TIPO_MANIPULACAO`),
  KEY `fk_documento_idx` (`DOCUMENTO`),
  KEY `fk_usuariomanipulacao_idx` (`USUARIO`),
  CONSTRAINT `fk_documento` FOREIGN KEY (`DOCUMENTO`) REFERENCES `tb_documento` (`registro`),
  CONSTRAINT `fk_manipulacao` FOREIGN KEY (`TIPO_MANIPULACAO`) REFERENCES `tb_documento_tipo_manipulacao` (`registro`),
  CONSTRAINT `fk_usuariomanipulacao` FOREIGN KEY (`USUARIO`) REFERENCES `tb_usuario` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_documento_manipulacao`
--

LOCK TABLES `tb_documento_manipulacao` WRITE;
/*!40000 ALTER TABLE `tb_documento_manipulacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_documento_manipulacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_documento_tipo_manipulacao`
--

DROP TABLE IF EXISTS `tb_documento_tipo_manipulacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_documento_tipo_manipulacao` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `descricao_acao` varchar(50) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_documento_tipo_manipulacao`
--

LOCK TABLES `tb_documento_tipo_manipulacao` WRITE;
/*!40000 ALTER TABLE `tb_documento_tipo_manipulacao` DISABLE KEYS */;
INSERT INTO `tb_documento_tipo_manipulacao` VALUES (1,'CAPTURA',_binary ''),(2,'INDEXACAO',_binary ''),(3,'REVISAO',_binary ''),(4,'ARMAZENAMENTO',_binary ''),(5,'CADASTRO',_binary '');
/*!40000 ALTER TABLE `tb_documento_tipo_manipulacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_estante`
--

DROP TABLE IF EXISTS `tb_estante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_estante` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `CORREDOR` int(11) NOT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `FK_corredor_idx` (`CORREDOR`),
  CONSTRAINT `FK_corredor` FOREIGN KEY (`CORREDOR`) REFERENCES `tb_corredor` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_estante`
--

LOCK TABLES `tb_estante` WRITE;
/*!40000 ALTER TABLE `tb_estante` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_estante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_grupo`
--

DROP TABLE IF EXISTS `tb_grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_grupo` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `nome_grupo` varchar(50) NOT NULL,
  `descricao_grupo` varchar(255) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_grupo`
--

LOCK TABLES `tb_grupo` WRITE;
/*!40000 ALTER TABLE `tb_grupo` DISABLE KEYS */;
INSERT INTO `tb_grupo` VALUES (1,'Master','Grupo Reservado',_binary ''),(2,'Geral','Usuários comuns',_binary '');
/*!40000 ALTER TABLE `tb_grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_log`
--

DROP TABLE IF EXISTS `tb_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_log` (
  `registro` bigint(20) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `acao` varchar(100) NOT NULL,
  `entidade` text,
  `usuario` varchar(100) DEFAULT NULL,
  `mensagem` text NOT NULL,
  PRIMARY KEY (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=263 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_log`
--

LOCK TABLES `tb_log` WRITE;
/*!40000 ALTER TABLE `tb_log` DISABLE KEYS */;
INSERT INTO `tb_log` VALUES (1,'2015-01-12 11:40:21','Acesso Negado',NULL,'','usu?rio ou senha incorreto()'),(2,'2015-01-12 14:33:06','Acesso',NULL,'','Acesso concedido'),(3,'2015-01-12 14:34:26','Caixa',NULL,'admin','Registro:1IdCaixa:cx001Descricao:Localizacao:est001Aberta:FalseDocumentos:'),(4,'2015-01-12 14:57:05','Salvar','Caixa','admin','Registro=1|IdCaixa=cx001|Descricao=|Localizacao=est001|Aberta=False|Documentos=|'),(5,'2015-01-12 16:13:46','Acesso','','','Acesso concedido'),(6,'2015-01-12 16:14:12','Acesso','','admin','Saiu do sistema'),(7,'2015-01-12 16:16:13','Acesso',NULL,'','Acesso concedido'),(8,'2015-01-12 16:17:11','Acesso',NULL,'admin','Acesso concedido'),(9,'2015-01-12 16:18:07','Acesso',NULL,'admin','Saiu do sistema'),(10,'2015-01-12 16:29:39','Acesso',NULL,'','usu?rio ou senha incorreto'),(11,'2015-01-12 16:34:40','Acesso',NULL,'','usu?rio ou senha incorreto'),(12,'2015-01-15 15:08:41','Acesso',NULL,'admin','Acesso concedido'),(13,'2015-01-15 15:29:17','Acesso',NULL,'admin','Acesso concedido'),(14,'2015-01-15 15:33:23','Salvar','Acao','admin','Registro=32|NomeAcao=Revis?o|DescricaoAcao=Revis?o de documentos|Grupos=|'),(15,'2015-01-15 15:51:10','Salvar','Caixa','admin','Registro=2|IdCaixa=CAIXA 02|Descricao=|Localizacao=|Aberta=True|Documentos=|'),(16,'2015-01-15 15:59:21','Acesso',NULL,'admin','Acesso concedido'),(17,'2015-01-15 16:00:30','Acesso',NULL,'admin','Acesso concedido'),(18,'2015-01-15 16:01:41','Acesso',NULL,'admin','Acesso concedido'),(19,'2015-01-15 16:12:38','Acesso',NULL,'admin','Acesso concedido'),(20,'2015-01-22 11:05:41','Acesso',NULL,'admin','Acesso concedido'),(21,'2015-01-22 11:20:13','Acesso',NULL,'admin','Acesso concedido'),(22,'2015-01-22 11:21:14','Acesso',NULL,'admin','Acesso concedido'),(23,'2015-01-22 11:29:45','Acesso',NULL,'admin','Acesso concedido'),(24,'2015-01-22 11:30:25','Salvar','Corredor','admin','Registro=1|Numero=1|Descricao=corredor1|Ativo=True|'),(25,'2015-01-22 11:33:44','Salvar','Estante','admin','Registro=1|Numero=1|Corredor=1|Descricao=|Ativo=True|FK_Corredor=|'),(26,'2015-01-22 11:33:58','Salvar','Estante','admin','Registro=1|Numero=1|Corredor=1|Descricao=Estante Principal|Ativo=True|FK_Corredor=|'),(27,'2015-01-22 11:37:27','Acesso',NULL,'admin','Acesso concedido'),(28,'2015-01-22 11:38:02','Salvar','Estante','admin','Registro=2|Numero=1|Corredor=1|Descricao=Estante Principal|Ativo=True|FK_Corredor=|'),(29,'2015-01-22 11:39:58','Salvar','Estante','admin','Registro=3|Numero=1|Corredor=1|Descricao=|Ativo=False|FK_Corredor=|'),(30,'2015-01-22 11:42:00','Salvar','Estante','admin','Registro=4|Numero=1|Corredor=1|Descricao=|Ativo=False|FK_Corredor=|'),(31,'2015-01-22 11:43:52','Acesso',NULL,'admin','Acesso concedido'),(32,'2015-01-22 14:25:52','Acesso',NULL,'admin','Acesso concedido'),(33,'2015-01-22 14:27:20','Acesso',NULL,'admin','Acesso concedido'),(34,'2015-01-22 14:49:44','Acesso',NULL,'admin','Acesso concedido'),(35,'2015-01-22 14:50:13','Salvar','Estante','admin','Registro=5|Numero=1|Corredor=1|Descricao=Estante Principal|Ativo=True|FK_Corredor=|'),(36,'2015-01-22 14:50:32','Salvar','Prateleira','admin','Registro=1|Numero=1|Estante=5|Descricao=prateleira1|Ativo=True|FK_Estante=|'),(37,'2015-01-22 14:52:17','Salvar','Prateleira','admin','Registro=2|Numero=2|Estante=5|Descricao=prateleira2|Ativo=True|FK_Estante=|'),(38,'2015-01-22 14:52:42','Salvar','Estante','admin','Registro=6|Numero=2|Corredor=1|Descricao=Estante Secund?ria|Ativo=True|FK_Corredor=|'),(39,'2015-01-22 14:54:39','Salvar','Prateleira','admin','Registro=3|Numero=3|Estante=6|Descricao=prateleira3|Ativo=True|FK_Estante=|'),(40,'2015-01-22 14:55:19','Salvar','Prateleira','admin','Registro=4|Numero=4|Estante=5|Descricao=tteste|Ativo=True|FK_Estante=|'),(41,'2015-01-22 15:04:04','Acesso',NULL,'admin','Acesso concedido'),(42,'2015-01-22 15:05:09','Salvar','Acao','admin','Registro=33|NomeAcao=Controlar Corredor|DescricaoAcao=Acesso ao controle de corredores.|Grupos=|'),(43,'2015-01-22 15:05:25','Salvar','Acao','admin','Registro=34|NomeAcao=Controlar Estante|DescricaoAcao=Acesso ao controle de estantes.|Grupos=|'),(44,'2015-01-22 15:05:46','Salvar','Acao','admin','Registro=35|NomeAcao=Controlar Prateleira|DescricaoAcao=Acesso ao controle de prateleiras.|Grupos=|'),(45,'2015-01-22 15:07:17','Acesso',NULL,'admin','Acesso concedido'),(46,'2015-01-22 15:29:07','Acesso',NULL,'admin','Acesso concedido'),(47,'2015-01-22 15:45:02','Acesso',NULL,'admin','Acesso concedido'),(48,'2015-01-22 15:46:36','Acesso',NULL,'admin','Acesso concedido'),(49,'2015-01-22 16:06:49','Acesso',NULL,'admin','Acesso concedido'),(50,'2015-01-22 16:08:14','Acesso',NULL,'admin','Acesso concedido'),(51,'2015-01-22 16:41:09','Acesso',NULL,'admin','Acesso concedido'),(52,'2015-01-22 16:42:30','Salvar','Caixa','admin','Registro=3|IdCaixa=cx001|Descricao=|Prateleira=1|Subserie=3|Aberta=True|Documentos=|FK_Prateleira=|FK_Subserie=|'),(53,'2015-01-22 17:15:26','Acesso',NULL,'admin','Acesso concedido'),(54,'2015-01-22 17:17:24','Acesso',NULL,'admin','Acesso concedido'),(55,'2015-01-22 17:18:01','Acesso',NULL,'admin','Acesso concedido'),(56,'2015-01-22 17:19:35','Acesso',NULL,'admin','Acesso concedido'),(57,'2015-01-22 17:21:52','Acesso',NULL,'admin','Acesso concedido'),(58,'2015-01-22 17:23:56','Acesso',NULL,'admin','Acesso concedido'),(59,'2015-01-22 17:25:25','Acesso',NULL,'admin','Acesso concedido'),(60,'2015-01-22 17:26:55','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 4)'),(61,'2015-01-22 17:32:42','Acesso',NULL,'admin','Acesso concedido'),(62,'2015-01-22 17:34:17','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 5)'),(63,'2015-01-22 17:41:30','Acesso',NULL,'admin','Acesso concedido'),(64,'2015-01-22 17:41:45','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 6)'),(65,'2015-01-22 17:41:59','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 7)'),(66,'2015-01-22 17:51:33','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 8)'),(67,'2015-01-22 17:53:11','Acesso',NULL,'admin','Acesso concedido'),(68,'2015-01-22 17:54:17','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 9)'),(69,'2015-01-22 17:54:25','Excluir','Documento_90E3CE93B97E241567771967EFB45E194545F5BA9D88029DD34A45CDDAABD8D3','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_6B887B3867BA7891E60302982F036ECBF0E68C87328FF53216214E687B234D29|FK_Caixa=|Registro=9|Dados=System.Byte[]|Subserie=1|DataCriacao=22/01/2015 17:54:15|Caixa=|'),(70,'2015-01-23 10:59:05','Acesso',NULL,'admin','Acesso concedido'),(71,'2015-01-23 11:02:11','Acesso',NULL,'admin','Acesso concedido'),(72,'2015-01-23 11:06:57','Acesso',NULL,'admin','Acesso concedido'),(73,'2015-01-23 11:13:34','Acesso',NULL,'admin','Acesso concedido'),(74,'2015-01-23 11:15:04','Acesso',NULL,'admin','Acesso concedido'),(75,'2015-01-23 11:19:03','Acesso',NULL,'admin','Acesso concedido'),(76,'2015-01-23 11:19:53','Acesso',NULL,'admin','Acesso concedido'),(77,'2015-01-23 11:20:37','Acesso',NULL,'admin','Acesso concedido'),(78,'2015-01-23 11:29:09','Acesso',NULL,'admin','Acesso concedido'),(79,'2015-01-23 15:16:44','Acesso',NULL,'admin','Acesso concedido'),(80,'2015-01-23 15:19:36','Acesso',NULL,'admin','Acesso concedido'),(81,'2015-01-23 15:25:18','Acesso',NULL,'admin','Acesso concedido'),(82,'2015-01-23 15:29:57','Acesso',NULL,'admin','Acesso concedido'),(83,'2015-01-23 15:33:35','Acesso',NULL,'admin','Acesso concedido'),(84,'2015-01-23 15:35:53','Acesso',NULL,'admin','Acesso concedido'),(85,'2015-01-23 15:37:58','Acesso',NULL,'admin','Acesso concedido'),(86,'2015-01-23 15:44:12','Acesso',NULL,'admin','Acesso concedido'),(87,'2015-01-23 15:45:49','Acesso',NULL,'admin','Acesso concedido'),(88,'2015-01-23 16:02:57','Acesso',NULL,'admin','Acesso concedido'),(89,'2015-01-23 16:05:18','Acesso',NULL,'admin','Acesso concedido'),(90,'2015-01-23 16:07:03','Acesso',NULL,'admin','Acesso concedido'),(91,'2015-01-23 16:18:11','Acesso',NULL,'admin','Acesso concedido'),(92,'2015-01-23 16:19:01','Acesso',NULL,'admin','Acesso concedido'),(93,'2015-01-23 16:20:44','Acesso',NULL,'admin','Acesso concedido'),(94,'2015-01-23 16:21:30','Acesso',NULL,'admin','Acesso concedido'),(95,'2015-01-23 16:22:21','Acesso',NULL,'admin','Acesso concedido'),(96,'2015-01-23 16:24:46','Acesso',NULL,'admin','Acesso concedido'),(97,'2015-01-23 16:28:31','Acesso',NULL,'admin','Acesso concedido'),(98,'2015-01-23 16:29:48','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 1)'),(99,'2015-01-23 16:34:13','Acesso',NULL,'admin','Acesso concedido'),(100,'2015-01-26 10:14:08','Acesso',NULL,'','usu?rio ou senha incorreto'),(101,'2015-01-26 10:14:23','Acesso',NULL,'admin','Acesso concedido'),(102,'2015-01-26 20:28:51','Acesso',NULL,'admin','Acesso concedido'),(103,'2015-01-26 20:29:33','Acesso',NULL,'admin','Acesso concedido'),(104,'2015-01-26 20:30:32','Acesso',NULL,'admin','Acesso concedido'),(105,'2015-01-26 20:46:19','Acesso',NULL,'admin','Acesso concedido'),(106,'2015-01-26 20:47:35','Acesso',NULL,'admin','Acesso concedido'),(107,'2015-01-26 20:57:54','Acesso',NULL,'admin','Acesso concedido'),(108,'2015-02-02 20:27:51','Acesso',NULL,'admin','Acesso concedido'),(109,'2015-02-02 20:30:53','Configura?',NULL,'admin','REMOVER PERMISS?O: A??O:Alterar Senha GRUPO:Master'),(110,'2015-02-02 20:30:54','Configura?',NULL,'admin','ADICIONAR PERMISS?O: A??O:Alterar Senha GRUPO:Master'),(111,'2015-02-02 20:49:54','Acesso',NULL,'admin','Acesso concedido'),(112,'2015-02-02 20:56:52','Salvar','Acao','admin','Registro=36|NomeAcao=Editar Indexa??o|DescricaoAcao=Editar valores de uma indexa??o realizada.|Grupos=|'),(113,'2015-02-02 20:57:07','Configura?',NULL,'admin','ADICIONAR PERMISS?O: A??O:Editar Indexa??o GRUPO:Master'),(114,'2015-02-02 20:57:38','Acesso',NULL,'admin','Acesso concedido'),(115,'2015-02-02 20:59:17','Acesso',NULL,'admin','Acesso concedido'),(116,'2015-02-02 20:59:57','Acesso',NULL,'admin','Acesso concedido'),(117,'2015-02-02 21:00:10','Acesso',NULL,'admin','Saiu do sistema'),(118,'2015-02-02 21:00:14','Acesso',NULL,'admin','Acesso concedido'),(119,'2015-02-02 21:02:59','Acesso',NULL,'admin','Acesso concedido'),(120,'2015-02-02 21:03:35','Configura?',NULL,'admin','ALTERAR SENHA. USU?RIO: admin'),(121,'2015-02-02 21:03:37','Configura?',NULL,'admin','ALTERAR SENHA. USU?RIO: admin'),(122,'2015-02-02 21:04:11','Acesso',NULL,'admin','Acesso concedido'),(123,'2015-02-02 21:04:31','Acesso',NULL,'admin','Saiu do sistema'),(124,'2015-02-02 21:09:58','Acesso',NULL,'','Acesso concedido'),(125,'2015-02-09 19:43:06','Acesso',NULL,'','usu?rio ou senha incorreto'),(126,'2015-02-09 19:43:30','Excluir','Documento_DE7AAA89DE941AC508B98FCD8F5D2D8786FBC4E040E6B877812CB8D6911DE50D','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=1|Dados=System.Byte[]|Subserie=3|DataCriacao=23/01/2015 16:29:39|Caixa=3|Descricao=teste|'),(127,'2015-02-11 20:30:28','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 2)'),(128,'2015-02-23 22:10:16','Acesso',NULL,'','Saiu do sistema'),(129,'2015-03-02 20:24:34','Acesso',NULL,'','usu?rio ou senha incorreto'),(130,'2015-03-02 20:25:19','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 3)'),(131,'2015-03-16 20:02:45','Editar','Documento','admin','Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|FK_Subserie=|FK_Caixa=|'),(132,'2015-03-16 20:03:01','Editar','Documento','admin','Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|FK_Subserie=|FK_Caixa=|'),(133,'2015-03-16 20:04:13','Salvar','Acao','admin','Registro=37|NomeAcao=Iniciar Revis?o|DescricaoAcao=Inicia o processo de confer?ncia de documentos.|Grupos=|'),(134,'2015-03-16 20:04:25','Configura?',NULL,'admin','ADICIONAR PERMISS?O: A??O:Iniciar Revis?o GRUPO:Master'),(135,'2015-03-16 22:54:45','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=2|Subserie=3|DataCriacao=11/02/2015 20:30:27|Caixa=3|Descricao=teste ap?s ajuste|'),(136,'2015-03-16 22:58:20','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(137,'2015-03-16 23:02:48','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(138,'2015-03-16 23:12:59','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=2|Subserie=3|DataCriacao=11/02/2015 20:30:27|Caixa=3|Descricao=teste ap?s ajuste|'),(139,'2015-03-16 23:15:20','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(140,'2015-03-16 23:19:41','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(141,'2015-03-16 23:20:05','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(142,'2015-03-16 23:20:31','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=System.Data.Entity.DynamicProxies.Subserie_23E47897857D5C78AB1C463A5752EDCA3129729DA465195D65183DF8A848B3B5|FK_Caixa=System.Data.Entity.DynamicProxies.Caixa_F449FE7F6282D9C67E9770FC6033EC694211D336945E201D08F18D0766636909|Registro=2|Subserie=3|DataCriacao=11/02/2015 20:30:27|Caixa=3|Descricao=teste ap?s ajuste|'),(143,'2015-03-18 21:16:12','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 4)'),(144,'2015-03-18 21:27:40','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 5)'),(145,'2015-03-18 21:35:44','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 6)'),(146,'2015-03-18 21:40:56','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 7)'),(147,'2015-03-30 20:36:20','Editar','Documento','admin','Registro=7|Subserie=3|DataCriacao=18/03/2015 21:40:56|Caixa=3|Descricao=teste3|FK_Subserie=|FK_Caixa=|'),(148,'2015-03-30 20:41:00','Editar','Documento','admin','Registro=7|Subserie=3|DataCriacao=18/03/2015 21:40:56|Caixa=3|Descricao=teste3|FK_Subserie=|FK_Caixa=|'),(149,'2015-03-30 20:42:25','Editar','Documento','admin','Registro=7|Subserie=3|DataCriacao=18/03/2015 21:40:56|Caixa=3|Descricao=teste3|FK_Subserie=|FK_Caixa=|'),(150,'2015-03-30 21:19:20','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 8)'),(151,'2015-03-30 21:24:59','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 9)'),(152,'2015-03-30 21:40:18','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 10)'),(153,'2015-05-06 21:08:43','Acesso',NULL,'','usu?rio ou senha incorreto'),(154,'2015-05-06 21:08:55','Acesso',NULL,'','usu?rio ou senha incorreto'),(155,'2015-05-06 21:29:33','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 11)'),(156,'2015-05-06 21:32:00','Configura?',NULL,'admin','ALTERAR SENHA. USU?RIO: admin'),(157,'2015-05-06 21:32:00','Editar','Usuario','admin','Registro=1|NomeUsuario=Administrador|Login=admin|Senha=1A0D0B99F43DA02CAEA450286B90ED45|DataCadastro=15/12/2014 00:00:00|Ativo=True|Grupos=|'),(158,'2015-05-06 21:32:13','Configura?',NULL,'admin','ALTERAR SENHA. USU?RIO: admin'),(159,'2015-05-06 21:32:13','Editar','Usuario','admin','Registro=1|NomeUsuario=Administrador do Sistema|Login=admin|Senha=78BE98CA51E475A6F3DAEDB2157547DA|DataCadastro=15/12/2014 00:00:00|Ativo=True|Grupos=|'),(160,'2015-05-06 21:32:34','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=11|Subserie=3|DataCriacao=06/05/2015 21:29:33|Caixa=3|Descricao=teste rota|'),(161,'2015-05-06 21:32:38','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=10|Subserie=3|DataCriacao=30/03/2015 21:40:18|Caixa=3|Descricao=natiruts|'),(162,'2015-05-06 21:32:41','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=9|Subserie=3|DataCriacao=30/03/2015 21:24:59|Caixa=3|Descricao=teste|'),(163,'2015-05-06 21:32:46','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=8|Subserie=3|DataCriacao=30/03/2015 21:19:20|Caixa=3|Descricao=teste previous page|'),(164,'2015-05-06 21:32:50','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=7|Subserie=3|DataCriacao=18/03/2015 21:40:56|Caixa=3|Descricao=teste3|'),(165,'2015-05-06 21:32:52','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=6|Subserie=3|DataCriacao=18/03/2015 21:35:44|Caixa=3|Descricao=teste2|'),(166,'2015-05-06 21:32:56','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=5|Subserie=3|DataCriacao=18/03/2015 21:27:40|Caixa=3|Descricao=teste|'),(167,'2015-05-06 21:32:59','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=4|Subserie=3|DataCriacao=18/03/2015 21:16:12|Caixa=3|Descricao=Editais Concurso|'),(168,'2015-05-06 21:33:02','Excluir','Documento_74BA992BFC6EA3E414595443FC8FE7F18CAA5B4F201FD8321FC7A65002941246','admin','FK_Subserie=|FK_Caixa=|Registro=3|Subserie=3|DataCriacao=02/03/2015 20:25:16|Caixa=3|Descricao=teste home|'),(169,'2015-05-11 21:43:56','Acesso',NULL,'','usu?rio ou senha incorreto'),(170,'2015-05-11 21:44:08','Acesso',NULL,'','usu?rio ou senha incorreto'),(171,'2015-05-11 21:45:31','Acesso',NULL,'','usu?rio ou senha incorreto'),(172,'2015-05-11 21:45:41','Acesso',NULL,'','usu?rio ou senha incorreto'),(173,'2015-05-11 21:45:48','Acesso',NULL,'','usu?rio ou senha incorreto'),(174,'2015-05-11 21:45:56','Acesso',NULL,'','usu?rio ou senha incorreto'),(175,'2015-05-11 21:46:03','Acesso',NULL,'','usu?rio ou senha incorreto'),(176,'2015-05-11 21:46:11','Acesso',NULL,'','usu?rio ou senha incorreto'),(177,'2015-05-11 21:46:20','Acesso',NULL,'','usu?rio ou senha incorreto'),(178,'2015-05-11 21:46:38','Acesso',NULL,'','usu?rio ou senha incorreto'),(179,'2015-05-11 21:46:46','Acesso',NULL,'','usu?rio ou senha incorreto'),(180,'2015-05-11 21:46:52','Acesso',NULL,'','usu?rio ou senha incorreto'),(181,'2015-05-11 21:48:22','Acesso',NULL,'','usu?rio ou senha incorreto'),(182,'2015-05-11 21:48:36','Acesso',NULL,'','usu?rio ou senha incorreto'),(183,'2015-05-11 21:48:48','Acesso',NULL,'','usu?rio ou senha incorreto'),(184,'2015-05-11 21:49:10','Acesso',NULL,'','usu?rio ou senha incorreto'),(185,'2015-05-11 21:50:41','Configura?',NULL,'admin','ALTERAR SENHA. USU?RIO: daniel'),(186,'2015-05-11 21:50:42','Salvar','Usuario','admin','Registro=2|NomeUsuario=Daniel Xavier Cardoso|Login=daniel|Senha=C7AD3CB704D036166104A2DE2147EE23|DataCadastro=11/05/2015 21:50:41|Ativo=True|Grupos=|'),(187,'2015-05-11 21:50:49','Configura?',NULL,'admin','ADICIONAR USU?RIO AO GRUPO: USU?RIO:daniel GRUPO:Master'),(188,'2015-09-23 22:11:10','Acesso',NULL,'','usuário ou senha incorreto'),(189,'2015-09-23 22:34:32','Acesso',NULL,'admin','Saiu do sistema'),(190,'2015-09-23 22:34:38','Acesso',NULL,'','usuário ou senha incorreto'),(191,'2015-09-23 22:34:46','Acesso',NULL,'','usuário ou senha incorreto'),(192,'2015-09-23 22:35:00','Acesso',NULL,'','usuário ou senha incorreto'),(193,'2015-09-23 22:35:28','Acesso',NULL,'','usuário ou senha incorreto'),(194,'2015-09-23 22:38:58','Acesso',NULL,'daniel','Saiu do sistema'),(195,'2015-10-08 21:24:44','Acesso',NULL,'','usuário ou senha incorreto'),(196,'2015-10-14 22:04:01','Acesso',NULL,'admin','Saiu do sistema'),(197,'2015-10-14 22:12:32','Salvar','Acao','admin','Registro=38|NomeAcao=Consulta Detalhada|DescricaoAcao=Consulta de documentos por índice.|Grupos=|'),(198,'2015-10-14 22:13:05','Configuração',NULL,'admin','ADICIONAR PERMISSÃO: AÇÃO:Consulta Detalhada GRUPO:Master'),(199,'2015-10-14 22:18:14','Excluir','SubserieIndice_F0EF92179AEAB82C90BAF42637454075BA0F55FE31B7A9E7525E15206B51B0DA','admin','FK_Subserie=|Registro=3|NomeIndice=Data|DescricaoIndice=data de envio|Subserie=3|Obrigatorio=False|'),(200,'2015-10-14 22:18:20','Excluir','SubserieIndice_F0EF92179AEAB82C90BAF42637454075BA0F55FE31B7A9E7525E15206B51B0DA','admin','FK_Subserie=|Registro=2|NomeIndice=Destinat?rio|DescricaoIndice=a quem ? destinada|Subserie=3|Obrigatorio=True|'),(201,'2015-10-14 22:18:23','Excluir','SubserieIndice_F0EF92179AEAB82C90BAF42637454075BA0F55FE31B7A9E7525E15206B51B0DA','admin','FK_Subserie=|Registro=1|NomeIndice=Numero da Comunica?|DescricaoIndice=Numero da ci|Subserie=3|Obrigatorio=True|'),(202,'2015-10-14 22:18:59','Salvar','Subserie','admin','Registro=1|Id_subserie=011.1|Rotulo_subserie=DOCUMENTAÇÃO ADMINISTRATIVA|Subserie_pai=|Serie=1|AceitaDocumentos=False|Ativo=True|FK_Subserie_pai=|FK_Serie=|'),(203,'2015-10-14 22:19:23','Salvar','Subserie','admin','Registro=2|Id_subserie=011.11|Rotulo_subserie=COMUNICAÇÃO INTERNA|Subserie_pai=1|Serie=1|AceitaDocumentos=False|Ativo=True|FK_Subserie_pai=|FK_Serie=|'),(204,'2015-10-14 22:19:44','Salvar','Subserie','admin','Registro=1|Id_subserie=011.1|Rotulo_subserie=DOCUMENTAÇÃO ADMINISTRATIVA|Subserie_pai=|Serie=1|AceitaDocumentos=True|Ativo=True|FK_Subserie_pai=|FK_Serie=|'),(205,'2015-10-14 22:19:52','Salvar','Subserie','admin','Registro=2|Id_subserie=011.11|Rotulo_subserie=COMUNICAÇÃO INTERNA|Subserie_pai=1|Serie=1|AceitaDocumentos=True|Ativo=True|FK_Subserie_pai=|FK_Serie=|'),(206,'2015-10-14 22:20:56','Salvar','Classe','admin','Registro=1|Id_classe=000|Rotulo=ADMINISTRAÇÃO|Ativo=True|DataAbertura=01/01/0001 00:00:00|'),(207,'2015-10-14 22:21:49','Salvar','SubserieIndice','admin','Registro=4|NomeIndice=Destinatário|DescricaoIndice=Destinatário da documentação|Subserie=1|Obrigatorio=True|FK_Subserie=|'),(208,'2015-10-14 22:22:04','Salvar','SubserieIndice','admin','Registro=5|NomeIndice=Destinatário|DescricaoIndice=Destinatário da documentação|Subserie=2|Obrigatorio=True|FK_Subserie=|'),(209,'2015-10-14 22:22:18','Salvar','SubserieIndice','admin','Registro=6|NomeIndice=Destinatário|DescricaoIndice=Destinatário da documentação|Subserie=3|Obrigatorio=True|FK_Subserie=|'),(210,'2015-10-14 22:22:45','Salvar','SubserieIndice','admin','Registro=7|NomeIndice=Data cadastro|DescricaoIndice=Data de cadastramento|Subserie=1|Obrigatorio=True|FK_Subserie=|'),(211,'2015-10-14 22:52:00','Acesso',NULL,'','usuário ou senha incorreto'),(212,'2015-10-14 22:56:26','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 1)'),(213,'2015-10-14 23:05:45','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 2)'),(214,'2015-10-21 22:58:21','Salvar','Caixa','admin','Registro=4|IdCaixa=cx002|Descricao=Documentação Admin|Prateleira=1|Subserie=1|Aberta=True|Documentos=|FK_Prateleira=|FK_Subserie=|'),(215,'2015-10-21 22:58:43','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 3)'),(216,'2015-10-21 23:10:16','Salvar','Acao','admin','Registro=39|NomeAcao=Controlar Subserie Usuario|DescricaoAcao=Abre a tela para configurar as subséries que o usuário poderá manipular.|Grupos=|'),(217,'2015-10-21 23:10:37','Configuração',NULL,'admin','ADICIONAR PERMISSÃO: AÇÃO:Controlar Subserie Usuario GRUPO:Master'),(218,'2015-10-21 23:19:32','Salvar','Acao','admin','Registro=39|NomeAcao=Controlar Subserie Usuario|DescricaoAcao=Adicionar ou remover as subséries que o usuário poderá manipular.|Grupos=|'),(219,'2015-10-21 23:19:48','Salvar','Acao','admin','Registro=40|NomeAcao=Visualizar Subserie Usuario|DescricaoAcao=Abre a tela para configurar as subséries que o usuário poderá manipular.|Grupos=|'),(220,'2015-10-21 23:20:32','Configuração',NULL,'admin','ADICIONAR PERMISSÃO: AÇÃO:Visualizar Subserie Usuario GRUPO:Master'),(221,'2015-11-17 03:00:51','Configuração',NULL,'admin','ALTERAR SENHA. USUÁRIO: felipe'),(222,'2015-11-17 03:00:51','Salvar','Usuario','admin','Registro=3|NomeUsuario=Felipe Freitas|Login=felipe|Senha=7E04DA88CBB8CC933C7B89FBFE121CCA|DataCadastro=11/17/2015 3:00:50 AM|Ativo=True|Grupos=|Subseries=|'),(223,'2015-11-17 03:01:06','Configuração',NULL,'admin','ADICIONAR USUÁRIO AO GRUPO: USUÁRIO:felipe GRUPO:Master'),(224,'2015-11-17 03:01:25','Acesso',NULL,'admin','Saiu do sistema'),(225,'2015-11-17 03:38:54','Acesso',NULL,'felipe','Saiu do sistema'),(226,'2015-11-17 03:53:57','Acesso',NULL,'admin','Saiu do sistema'),(227,'2015-11-17 04:34:15','Acesso',NULL,'felipe','Saiu do sistema'),(228,'2015-11-17 14:29:34','Acesso',NULL,'','Saiu do sistema'),(229,'2015-11-17 14:29:45','Acesso',NULL,'','usuário ou senha incorreto'),(230,'2015-11-23 01:06:01','Salvar',NULL,'felipe','CADASTRO DE DOCUMENTO (REGISTRO 4)'),(231,'2015-11-23 01:10:45','Salvar','SubserieIndice','felipe','Registro=8|NomeIndice=Numero da CI|DescricaoIndice=o numero do documento|Subserie=3|Obrigatorio=True|FK_Subserie=|'),(232,'2015-11-23 01:11:09','Salvar','SubserieIndice','felipe','Registro=9|NomeIndice=Data|DescricaoIndice=Data da CI|Subserie=3|Obrigatorio=True|FK_Subserie=|'),(233,'2015-11-23 01:22:02','Salvar','SubserieIndice','felipe','Registro=10|NomeIndice=Numero do Documento|DescricaoIndice=Numero do documento|Subserie=1|Obrigatorio=True|FK_Subserie=|'),(234,'2015-11-23 01:22:33','Salvar','SubserieIndice','felipe','Registro=11|NomeIndice=data|DescricaoIndice=data|Subserie=2|Obrigatorio=True|FK_Subserie=|'),(235,'2015-11-23 01:22:49','Salvar','SubserieIndice','felipe','Registro=12|NomeIndice=numero do Documento|DescricaoIndice=numero do documento|Subserie=2|Obrigatorio=True|FK_Subserie=|'),(236,'2015-11-23 01:24:46','Salvar',NULL,'felipe','CADASTRO DE DOCUMENTO (REGISTRO 5)'),(237,'2015-11-23 01:28:21','Acesso',NULL,'felipe','Saiu do sistema'),(238,'2016-01-06 22:50:09','Configuração',NULL,'felipe','ALTERAR SENHA. USUÁRIO: Estagiario'),(239,'2016-01-06 22:50:09','Salvar','Usuario','felipe','Registro=4|NomeUsuario=Estagiario|Login=Estagiario|Senha=6A1AA83CD6E67D59BE423969975E9FAB|DataCadastro=1/6/2016 10:50:08 PM|Ativo=True|Grupos=|Subseries=|'),(240,'2016-01-06 22:50:25','Configuração',NULL,'felipe','ADICIONAR USUÁRIO AO GRUPO: USUÁRIO:Estagiario GRUPO:Master'),(241,'2016-01-06 22:50:28','Configuração',NULL,'felipe','REMOVER USUÁRIO DO GRUPO: USUÁRIO:Estagiario GRUPO:Master'),(242,'2016-01-06 22:50:54','Salvar','Grupo','felipe','Registro=2|NomeGrupo=Estagiarios|DescricaoGrupo=Estagiarios|Ativo=True|Acoes=|'),(243,'2016-01-06 22:51:23','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Armazenar Documento GRUPO:Estagiarios'),(244,'2016-01-06 22:51:32','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Cadastrar Documento GRUPO:Estagiarios'),(245,'2016-01-06 22:51:45','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Consulta Detalhada GRUPO:Estagiarios'),(246,'2016-01-06 22:52:39','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Indexação GRUPO:Estagiarios'),(247,'2016-01-06 22:52:48','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Iniciar Revisão GRUPO:Estagiarios'),(248,'2016-01-06 22:52:58','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Listar Documentos Não Revisados GRUPO:Estagiarios'),(249,'2016-01-06 22:53:10','Configuração',NULL,'felipe','ADICIONAR PERMISSÃO: AÇÃO:Revisão GRUPO:Estagiarios'),(250,'2016-01-06 22:53:38','Acesso',NULL,'felipe','Saiu do sistema'),(251,'2016-01-06 22:54:35','Acesso',NULL,'Estagiario','Saiu do sistema'),(252,'2016-01-06 22:55:05','Configuração',NULL,'felipe','ADICIONAR USUÁRIO AO GRUPO: USUÁRIO:Estagiario GRUPO:Estagiarios'),(253,'2016-01-06 22:55:30','Acesso',NULL,'felipe','Saiu do sistema'),(254,'2016-01-06 22:55:57','Acesso',NULL,'Estagiario','Saiu do sistema'),(255,'2016-01-06 22:56:38','Acesso',NULL,'felipe','Saiu do sistema'),(256,'2016-01-06 22:57:26','Salvar',NULL,'Estagiario','CADASTRO DE DOCUMENTO (REGISTRO 6)'),(257,'2016-01-06 23:07:43','Salvar',NULL,'Estagiario','CADASTRO DE DOCUMENTO (REGISTRO 7)'),(258,'2016-01-06 23:36:18','Acesso',NULL,'','Saiu do sistema'),(259,'2016-01-06 23:36:37','Acesso',NULL,'','Saiu do sistema'),(260,'2020-01-22 20:40:17','Salvar','Caixa','admin','Registro=5|IdCaixa=Padrão|Descricao=Caixa padrão teste|Prateleira=1|Subserie=1|Aberta=True|Documentos=|FK_Prateleira=|FK_Subserie=|'),(261,'2020-01-22 20:40:34','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 8)'),(262,'2020-01-22 20:40:57','Salvar',NULL,'admin','CADASTRO DE DOCUMENTO (REGISTRO 9)');
/*!40000 ALTER TABLE `tb_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_prateleira`
--

DROP TABLE IF EXISTS `tb_prateleira`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_prateleira` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `ESTANTE` int(11) NOT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `FK_estante_idx` (`ESTANTE`),
  CONSTRAINT `FK_estante` FOREIGN KEY (`ESTANTE`) REFERENCES `tb_estante` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_prateleira`
--

LOCK TABLES `tb_prateleira` WRITE;
/*!40000 ALTER TABLE `tb_prateleira` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_prateleira` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_prazo_guarda`
--

DROP TABLE IF EXISTS `tb_prazo_guarda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_prazo_guarda` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `corrente` varchar(10) DEFAULT NULL,
  `intermediario` varchar(10) DEFAULT NULL,
  `permanente` bit(1) NOT NULL,
  `SUBSERIE` int(11) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_subserieprazo_idx` (`SUBSERIE`),
  CONSTRAINT `fk_subserieprazo` FOREIGN KEY (`SUBSERIE`) REFERENCES `tb_subserie` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_prazo_guarda`
--

LOCK TABLES `tb_prazo_guarda` WRITE;
/*!40000 ALTER TABLE `tb_prazo_guarda` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_prazo_guarda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_serie`
--

DROP TABLE IF EXISTS `tb_serie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_serie` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `id_serie` char(3) NOT NULL,
  `rotulo_serie` varchar(100) NOT NULL,
  `SUBCLASSE` int(11) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `id_serie_UNIQUE` (`id_serie`),
  KEY `fk_subclasse_idx` (`SUBCLASSE`),
  CONSTRAINT `fk_subclasse` FOREIGN KEY (`SUBCLASSE`) REFERENCES `tb_subclasse` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_serie`
--

LOCK TABLES `tb_serie` WRITE;
/*!40000 ALTER TABLE `tb_serie` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_serie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_subclasse`
--

DROP TABLE IF EXISTS `tb_subclasse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_subclasse` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `id_subclasse` char(3) NOT NULL,
  `rotulo_subclasse` varchar(100) NOT NULL,
  `CLASSE` int(11) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `id_subclasse_UNIQUE` (`id_subclasse`),
  KEY `fk_classe_idx` (`CLASSE`),
  CONSTRAINT `fk_classe` FOREIGN KEY (`CLASSE`) REFERENCES `tb_classe` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_subclasse`
--

LOCK TABLES `tb_subclasse` WRITE;
/*!40000 ALTER TABLE `tb_subclasse` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_subclasse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_subserie`
--

DROP TABLE IF EXISTS `tb_subserie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_subserie` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `id_subserie` varchar(255) NOT NULL,
  `rotulo_subserie` varchar(255) NOT NULL,
  `subserie_pai` int(11) DEFAULT NULL,
  `SERIE` int(11) NOT NULL,
  `aceita_documentos` bit(1) NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `id_subserie_UNIQUE` (`id_subserie`),
  KEY `fk_serie_idx` (`SERIE`),
  KEY `fk_subserie_idx` (`subserie_pai`),
  CONSTRAINT `fk_serie` FOREIGN KEY (`SERIE`) REFERENCES `tb_serie` (`registro`),
  CONSTRAINT `fk_subserie` FOREIGN KEY (`subserie_pai`) REFERENCES `tb_subserie` (`registro`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_subserie`
--

LOCK TABLES `tb_subserie` WRITE;
/*!40000 ALTER TABLE `tb_subserie` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_subserie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_subserie_indice`
--

DROP TABLE IF EXISTS `tb_subserie_indice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_subserie_indice` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `nome_indice` varchar(50) NOT NULL,
  `descricao_indice` varchar(200) NOT NULL,
  `SUBSERIE` int(11) NOT NULL,
  `obrigatorio` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_subserie_idx` (`SUBSERIE`),
  CONSTRAINT `fk_subserieindice` FOREIGN KEY (`SUBSERIE`) REFERENCES `tb_subserie` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_subserie_indice`
--

LOCK TABLES `tb_subserie_indice` WRITE;
/*!40000 ALTER TABLE `tb_subserie_indice` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_subserie_indice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_subserie_indice_valor`
--

DROP TABLE IF EXISTS `tb_subserie_indice_valor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_subserie_indice_valor` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `INDICE` int(11) NOT NULL,
  `DOCUMENTO` int(11) NOT NULL,
  `valor` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`registro`),
  KEY `fk_indice_idx` (`INDICE`),
  KEY `fk_documentovalor_idx` (`DOCUMENTO`),
  CONSTRAINT `fk_documentovalor` FOREIGN KEY (`DOCUMENTO`) REFERENCES `tb_documento` (`registro`),
  CONSTRAINT `fk_indice` FOREIGN KEY (`INDICE`) REFERENCES `tb_subserie_indice` (`registro`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_subserie_indice_valor`
--

LOCK TABLES `tb_subserie_indice_valor` WRITE;
/*!40000 ALTER TABLE `tb_subserie_indice_valor` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_subserie_indice_valor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_subserie_usuario`
--

DROP TABLE IF EXISTS `tb_subserie_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_subserie_usuario` (
  `SUBSERIE` int(11) NOT NULL,
  `USUARIO` int(11) NOT NULL,
  PRIMARY KEY (`SUBSERIE`,`USUARIO`),
  KEY `fk_su_usuario_idx` (`USUARIO`),
  CONSTRAINT `fk_su_subserie` FOREIGN KEY (`SUBSERIE`) REFERENCES `tb_subserie` (`registro`),
  CONSTRAINT `fk_su_usuario` FOREIGN KEY (`USUARIO`) REFERENCES `tb_usuario` (`registro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_subserie_usuario`
--

LOCK TABLES `tb_subserie_usuario` WRITE;
/*!40000 ALTER TABLE `tb_subserie_usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_subserie_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_usuario`
--

DROP TABLE IF EXISTS `tb_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_usuario` (
  `registro` int(11) NOT NULL AUTO_INCREMENT,
  `nome_usuario` varchar(100) NOT NULL,
  `login` varchar(100) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `data_cadastro` datetime NOT NULL,
  `ativo` bit(1) NOT NULL,
  PRIMARY KEY (`registro`),
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_usuario`
--

LOCK TABLES `tb_usuario` WRITE;
/*!40000 ALTER TABLE `tb_usuario` DISABLE KEYS */;
INSERT INTO `tb_usuario` VALUES (1,'Administrador do Sistema','admin','B13DAFF20E137AFD905BD14BCA66A505','2014-12-15 00:00:00',_binary '');
/*!40000 ALTER TABLE `tb_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_usuario_grupo`
--

DROP TABLE IF EXISTS `tb_usuario_grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_usuario_grupo` (
  `USUARIO` int(11) NOT NULL,
  `GRUPO` int(11) NOT NULL,
  PRIMARY KEY (`USUARIO`,`GRUPO`),
  KEY `fk_grupo_idx` (`GRUPO`),
  CONSTRAINT `fk_grupousuario` FOREIGN KEY (`GRUPO`) REFERENCES `tb_grupo` (`registro`),
  CONSTRAINT `fk_usuario` FOREIGN KEY (`USUARIO`) REFERENCES `tb_usuario` (`registro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_usuario_grupo`
--

LOCK TABLES `tb_usuario_grupo` WRITE;
/*!40000 ALTER TABLE `tb_usuario_grupo` DISABLE KEYS */;
INSERT INTO `tb_usuario_grupo` VALUES (1,1);
/*!40000 ALTER TABLE `tb_usuario_grupo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-29 22:19:44
