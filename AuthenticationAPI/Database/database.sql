-- Active: 1688201044465@@127.0.0.1@3306@authentication
DROP DATABASE IF EXISTS authentication;
CREATE DATABASE  authentication;
USE authentication;
CREATE TABLE credentials(id INT PRIMARY KEY AUTO_INCREMENT,contactnumber  VARCHAR(15) UNIQUE,
 password VARCHAR(25), createddate DATETIME DEFAULT CURRENT_TIMESTAMP,
 modifieddate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP);
 
INSERT INTO credentials (contactnumber,password) VALUES ('1245987456','password');
INSERT INTO credentials (contactnumber,password) VALUES ('8456123654','password');
INSERT INTO credentials (contactnumber,password) VALUES ('9999999999','password');
INSERT INTO credentials (contactnumber,password) VALUES ('9870223344','password');
INSERT INTO credentials (contactnumber,password) VALUES ('8530728589','password');

UPDATE credentials SET password='12345678' WHERE id=5;
SELECT * FROM credentials;

SELECT EXISTS(SELECT * FROM credentials WHERE contactnumber='8530728589' AND password='12345678');