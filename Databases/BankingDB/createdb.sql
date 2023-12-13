-- Active: 1696576841746@@127.0.0.1@3306@bankingdb
DROP DATABASE IF EXISTS BankingDB;
CREATE DATABASE BankingDB;
USE BankingDB;

CREATE TABLE
    customers(
        id INT AUTO_INCREMENT PRIMARY KEY,
        bankcustomerid INT NOT NULL,
        usertype ENUM("C", "I") NOT NULL
    );

CREATE TABLE
    accounts(
        id INT PRIMARY KEY AUTO_INCREMENT,
        acctnumber VARCHAR(20) NOT NULL,
        accttype ENUM(
            'savings',
            'business',
            'current'
        ),
        ifsccode VARCHAR(20),
        balance DOUBLE,
        registereddate DATE,
        customerid INT NOT NULL,
        CONSTRAINT fk_customerid FOREIGN KEY(customerid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE
    );

CREATE TABLE
    operations(
        operationid INT PRIMARY KEY AUTO_INCREMENT,
        acctId INT NOT NULL,
        CONSTRAINT fk_acctId FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE,
        acctnumber VARCHAR(20) NOT NULL,
        amount DOUBLE,
        operationdate DATETIME,
        operationmode ENUM('D','W'),
        operationtype ENUM("Interest","EMI","Transfer")
    );

CREATE TABLE
    transactions(
        id INT PRIMARY KEY AUTO_INCREMENT,
        fromoperationid INT NOT NULL,
        tooperationid INT NOT NULL,
        transactiondate datetime default current_timestamp,
        CONSTRAINT fk_operationid FOREIGN KEY(fromoperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT fk_rooperationid FOREIGN KEY(tooperationid) REFERENCES operations(operationid) ON UPDATE CASCADE ON DELETE CASCADE
    );

CREATE TABLE
    loan(
        loanid INT PRIMARY KEY AUTO_INCREMENT,
        amount DOUBLE,
        loansanctiondate DATE,
        duration INT,
		emiday INT,
		emiamount DOUBLE,
        intrestrate DOUBLE,
        acctId INT NOT NULL,
        CONSTRAINT fk_acctId2 FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE
    );
Drop table loanapplicants;

CREATE TABLE
    loanapplicants(
        applicatid INT PRIMARY KEY AUTO_INCREMENT,
        accountid INT NOT NULL,
        CONSTRAINT fk_accountid FOREIGN KEY (accountid) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE,
		applydate DATE,
        panid VARCHAR(10),
        loanamount double,
        loantype ENUM(
            "home",
            "personal",
            "business"
        ),
         loanstatus ENUM("applied","approved","rejected") DEFAULT "applied"
    );
    
