DROP DATABASE IF EXISTS  CorporateDB;

CREATE DATABASE CorporateDB;
USE CorporateDB;

CREATE TABLE corporate(id INT PRIMARY KEY AUTO_INCREMENT,
					  companyname VARCHAR(30) NOT NULL,
                      contactnumber VARCHAR(30) NOT NULL,
                      email VARCHAR(30) NOT NULL,
                      contactperson VARCHAR(30) NOT NULL
                      );
