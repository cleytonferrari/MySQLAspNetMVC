# Exemplo de uso do drive do MySql #

Exemplo de como usar ASP.Net MVC com o MySQL, criado um cadastro simples de pessoa, somente com o nome da pessoa.

##Esquema do Banco de dados Usado##
	CREATE DATABASE `karol` /* DEFAULT CHARACTER SET utf8 */;

	CREATE TABLE `pessoa` (
		`Id` int(11) NOT NULL AUTO_INCREMENT,
		`Nome` varchar(100) DEFAULT NULL,
		PRIMARY KEY (`Id`)
	);

