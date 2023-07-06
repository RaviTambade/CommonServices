-- Active: 1677341008727@@127.0.0.1@3306@eagroservicesdb
DROP DATABASE IF EXISTS  BankingDB;

CREATE DATABASE BankingDB;
USE BankingDB;

CREATE TABLE accounts(id INT PRIMARY KEY AUTO_INCREMENT,
					  acctnumber VARCHAR(20) NOT NULL,
                      accttype ENUM('savings','business','current'),
                      ifsccode VARCHAR(20),
                      balance DOUBLE,
                      registereddate DATE ,
                      peopleid INT NOT NULL
                      );
                      
CREATE TABLE operations(operationid INT PRIMARY KEY AUTO_INCREMENT,
					  acctId INT NOT NULL,
                      CONSTRAINT fk_acctId FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE,
                       acctnumber VARCHAR(20) NOT NULL,
                      amount DOUBLE,
                      operationdate DATETIME ,
                      operationmode CHAR
                      );

CREATE TABLE
    transactions(
        id INT PRIMARY KEY AUTO_INCREMENT,
        fromoperationid INT NOT NULL,
        tooperationid INT NOT NULL,
        CONSTRAINT fk_operationid FOREIGN KEY(fromoperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT fk_rooperationid FOREIGN KEY(tooperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE
    );

