-- Active: 1682349138553@@127.0.0.1@3306@usersdb
DROP DATABASE IF EXISTS usersdb;
CREATE DATABASE usersdb;
USE usersdb;

CREATE TABLE users(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     imageurl VARCHAR(50),
                     aadharid VARCHAR(30) NOT NULL UNIQUE,
                     firstname VARCHAR(50),
                     lastname VARCHAR(50),
                     birthdate DATE,
                     gender VARCHAR(40),
                     email VARCHAR(40),
                     contactnumber VARCHAR(40));
                     
CREATE TABLE  locations (id INT PRIMARY KEY AUTO_INCREMENT,
						userid int,constraint fk_users_addresses foreign key(userid) references users(id) on update cascade on delete cascade,
						longitude varchar(30),
                        latitude varchar(30),
                        landmark varchar(30),
						pincode varchar(30));

CREATE TABLE addresses (
                        id INT PRIMARY KEY AUTO_INCREMENT,
						userid INT,constraint fk_users_address foreign key(userid) references users(id) on update cascade on delete cascade,
                        area  varchar(50) NOT NULL,    
                        landmark varchar(50),
                        city varchar(20) NOT NULL,
                        state varchar(20) NOT NULL,
                        alternatecontactnumber varchar(20),
						pincode varchar(10) NOT NULL
);
