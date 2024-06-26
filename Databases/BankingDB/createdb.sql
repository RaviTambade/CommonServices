-- Active: 1705924796699@@127.0.0.1@3306@bankingdb
DROP DATABASE IF EXISTS BankingDB;
CREATE DATABASE BankingDB;
USE BankingDB;

CREATE TABLE customers(
    id INT AUTO_INCREMENT PRIMARY KEY,
    customerid INT NOT NULL,
    customertype ENUM("C", "I") NOT NULL
);

CREATE TABLE  accounts(
    id INT PRIMARY KEY AUTO_INCREMENT,
    acctnumber VARCHAR(20) NOT NULL,
    ifsccode VARCHAR(20),
    accttype ENUM('savings','business','current'),
    balance DOUBLE,
    registrationdate DATE,
    customerid INT NOT NULL,
    CONSTRAINT fk_customers_accounts_customerid FOREIGN KEY(customerid) REFERENCES customers(id) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE operations(
    id INT PRIMARY KEY AUTO_INCREMENT,
    acctId INT NOT NULL,
    acctnumber VARCHAR(20) NOT NULL,
    amount DOUBLE,
    operationdate DATETIME,
    operationmode ENUM('D','W'),
    operationtype ENUM("Interest","EMI","Transfer"),
    CONSTRAINT fk_accounts_operations_acctId FOREIGN KEY(acctId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE
    );

CREATE TABLE  transactions(
    id INT PRIMARY KEY AUTO_INCREMENT,
    fromoperationid INT NOT NULL,
    tooperationid INT NOT NULL,
    transactiondate datetime default current_timestamp,
    CONSTRAINT fk_operations_transactions_from FOREIGN KEY(fromoperationid) REFERENCES operations(id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT fk_operations_transactions_to FOREIGN KEY(tooperationid) REFERENCES operations(id) ON UPDATE CASCADE ON DELETE CASCADE
);
    
CREATE TABLE loantypes(
    id INT PRIMARY KEY AUTO_INCREMENT,
    loantype VARCHAR(20),
    intrestrate DOUBLE
) AUTO_INCREMENT=100;
        
CREATE TABLE loanapplications(
        id INT PRIMARY KEY AUTO_INCREMENT,
        applicationdate DATE,
        amount double,
        duration INT,
		status ENUM("applied","approved","rejected") DEFAULT "applied",
        accountid INT NOT NULL,
        loantypeid INT NOT NULL,
        CONSTRAINT fk_loantypes_loanapplications_loantypeid FOREIGN KEY(loantypeid) REFERENCES loantypes(id)  ON UPDATE CASCADE ON DELETE CASCADE,
        CONSTRAINT fk_accounts_loanapplications_accountid FOREIGN KEY (accountid) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE
    );

CREATE TABLE loan(
        loanid INT PRIMARY KEY AUTO_INCREMENT,
        loansanctiondate DATE,
        emiday INT DEFAULT 10,
		emiamount DOUBLE,
        applicationid INT NOT NULL,
<<<<<<< HEAD
        CONSTRAINT fk_loanapplications_loan_applicationid FOREIGN KEY(applicationid) REFERENCES loanapplications(id) ON UPDATE CASCADE ON DELETE CASCADE
=======
        CONSTRAINT fk_loanapplications_loan_applicationid FOREIGN KEY (applicationid) REFERENCES loanapplications(id) ON UPDATE CASCADE ON DELETE CASCADE
>>>>>>> e519588b39b8691c72d50190c4c0b962bd4fb5e5
    );


DELIMITER //
CREATE TRIGGER balance AFTER INSERT ON accounts 
for each row
BEGIN
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype) VALUES(NEW.id,NEW.acctnumber,NEW.balance,curdate(),"D","Transfer");
END //
DELIMITER ;

