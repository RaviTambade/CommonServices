-- Active: 1678339848098@@127.0.0.1@3306@corporatedb
DROP DATABASE IF EXISTS CorporateDB;

CREATE DATABASE CorporateDB;

USE CorporateDB;

<<<<<<< HEAD
CREATE TABLE corporations(id INT PRIMARY KEY AUTO_INCREMENT,
					  name VARCHAR(30) NOT NULL,
                      contactnumber VARCHAR(30) NOT NULL,
                      email VARCHAR(30) NOT NULL,
                      contactperson VARCHAR(30) NOT NULL
                      );
=======
CREATE TABLE corporations(
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(30) NOT NULL,
        contactnumber VARCHAR(30) NOT NULL UNIQUE,
        email VARCHAR(30) NOT NULL,
        personid INT NOT NULL 
    );
    
>>>>>>> ed488448def08a1d58e7e582604a607b024bdbab
