-- Active: 1696576841746@@127.0.0.1@3306@corporatedb
DROP DATABASE IF EXISTS CorporateDB;

CREATE DATABASE CorporateDB;

USE CorporateDB;


CREATE TABLE corporations(
        id INT PRIMARY KEY AUTO_INCREMENT,
        corporationid int NOT NULL UNIQUE,
        pannumber varchar(20),
        name VARCHAR(30) NOT NULL,
        contactnumber VARCHAR(30) NOT NULL UNIQUE,
        email VARCHAR(30) NOT NULL,
        userid INT NOT NULL 
    );
    
