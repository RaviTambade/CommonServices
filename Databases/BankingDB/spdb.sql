-- Active: 1696576841746@@127.0.0.1@3306@bankingdb
DELIMITER $$
CREATE PROCEDURE fundtransfer(IN fromaccountnumber VARCHAR(20),IN toaccountnumber VARCHAR(20),
                             IN fromifsccode VARCHAR(20),IN toifsccode VARCHAR(20),
                             IN amount DOUBLE,OUT transactionId INT)
BEGIN
DECLARE fromaccountid INT DEFAULT 0;
DECLARE toaccountid INT DEFAULT 0;
DECLARE fromoperationid INT DEFAULT 0;
DECLARE tooperationid INT DEFAULT 0;
DECLARE fromaccountbalance DOUBLE DEFAULT 0;
DECLARE toaccountbalance DOUBLE DEFAULT 0;
SELECT id,balance INTO fromaccountid,fromaccountbalance FROM accounts WHERE  acctnumber=fromaccountnumber AND ifsccode=fromifsccode;
SELECT id,balance INTO toaccountid,toaccountbalance FROM accounts WHERE  acctnumber=toaccountnumber AND ifsccode =toifsccode;    
INSERT INTO operations(acctId,acctnumber,amount,operationmode,operationdate)
VALUES(fromaccountid,fromaccountnumber,amount,'W',NOW());
SET fromoperationid=LAST_INSERT_ID();
UPDATE accounts SET balance=fromaccountbalance-amount WHERE id=fromaccountid;
INSERT INTO operations(acctId,acctnumber,amount,operationmode,operationdate)
VALUES(toaccountid,toaccountnumber,amount,'D',NOW());
SET tooperationid=LAST_INSERT_ID();
UPDATE accounts SET balance=toaccountbalance+amount WHERE id=toaccountid;
INSERT INTO transactions (fromoperationid,tooperationid) VALUES (fromoperationid,tooperationid);
SET transactionId=LAST_INSERT_ID();
END $$ 
DELIMITER; 

DELIMITER $$
CREATE PROCEDURE claculateIntrest(IN accountnumber VARCHAR(20))
BEGIN

DECLARE Balance DOUBLE DEFAULT 0;
DECLARE totaldays INT DEFAULT 0;
DECLARE intrestrate INT DEFAULT 0.07;
DECLARE Registereddate DATE ;

SELECT registereddate,balance INTO Registereddate,Balance FROM accounts WHERE acctnumber=accountnumber;
SELECT DATEDIFF(CURDATE(),Registereddate) INTO totaldays;
IF totaldays > 365 THEN
SET Balance=balance+intrestrate*balance;
UPDATE accounts SET balance=Balance WHERE acctnumber=accountnumber;
END IF;

END $$
DELIMITER ;

CALL claculateIntrest('67675456546');

DROP procedure claculateIntrest;

SELECT DATEDIFF(CURDATE(),"2022-04-21") ;


