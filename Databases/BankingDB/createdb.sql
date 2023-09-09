-- Active: 1678339848098@@127.0.0.1@3306@bankingdb
DROP DATABASE IF EXISTS  BankingDB;

CREATE DATABASE BankingDB;
USE BankingDB;

CREATE TABLE customers(id INT AUTO_INCREMENT PRIMARY KEY,
                       customerid INT NOT NULL UNIQUE,
                       dependancyid INT NOT NULL,
                       usertype ENUM("corporation","person") NOT NULL
                       );
                       
CREATE TABLE accounts(id INT PRIMARY KEY AUTO_INCREMENT,
					  acctnumber VARCHAR(20) NOT NULL,
                      accttype ENUM('savings','business','current'),
                      ifsccode VARCHAR(20),
                      balance DOUBLE,
                      registereddate DATE ,
                      customerid INT NOT NULL,
                      CONSTRAINT fk_customerid FOREIGN KEY(customerid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE
                      );
                      
CREATE TABLE operations(operationid INT PRIMARY KEY AUTO_INCREMENT,
					  acctId INT NOT NULL,
                      CONSTRAINT fk_acctId FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE,
                       acctnumber VARCHAR(20) NOT NULL,
                      amount DOUBLE,
                      operationdate DATETIME ,
                      operationmode CHAR
                      );
                      
CREATE TABLE transactions(id INT PRIMARY KEY AUTO_INCREMENT,
					fromoperationid INT NOT NULL,
					tooperationid INT NOT NULL,
					CONSTRAINT fk_operationid FOREIGN KEY(fromoperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE,
					CONSTRAINT fk_rooperationid FOREIGN KEY(tooperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE
					);                    
                    
CREATE TABLE loan(loanid INT PRIMARY KEY AUTO_INCREMENT,
						amount DOUBLE,
                        loansanctiondate DATE ,
                        duration INT,
                        intrestrate DOUBLE,
						acctId INT NOT NULL,
						CONSTRAINT fk_acctId FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE
                        );
ALTER TABLE loan MODIFY loansanctiondate DATE;
                       
CREATE TABLE loanorder(loanorderid INT PRIMARY KEY AUTO_INCREMENT,
						amount DOUBLE,                        
						loanid INT NOT NULL,
						CONSTRAINT fk_loanId FOREIGN KEY(loanid) REFERENCES loan(loanid) ON UPDATE CASCADE ON DELETE CASCADE
						);  

                    
CREATE TABLE installment(installmentid INT PRIMARY KEY AUTO_INCREMENT,
						amount DOUBLE,
						InstallmentDate DATETIME ,
                        loanorderid INT NOT NULL,
						CONSTRAINT fk_loanorderId FOREIGN KEY(loanorderid) REFERENCES loanorder(loanorderid) ON UPDATE CASCADE ON DELETE CASCADE						
						);

                      
 CREATE TABLE  loanapplicants( applicatid INT PRIMARY KEY AUTO_INCREMENT,
						accountid INT NOT NULL,
                        CONSTRAINT fk_accountid FOREIGN KEY (accountid) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE,
                        firstname VARCHAR(50),
                        middlename VARCHAR(50),
                        lastname VARCHAR(50),
                        birthdate DATE,
                        gender ENUM("male","female") NOT NULL,
                        contactnumber VARCHAR(10),
                        email VARCHAR(60),
                        address VARCHAR(150),
                        adharid  VARCHAR(16),
                        panid  VARCHAR(10) ,
                        loantype ENUM("home","personal","bussiness")
                        );
                        
ALTER TABLE loanapplicants MODIFY adharid VARCHAR(25);
                        
                        
select * from loanapplicants
                        
                        
						


