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



DROP procedure claculateIntrest;

DELIMITER $$
CREATE PROCEDURE claculateIntrest(IN accountnumber VARCHAR(20))
BEGIN
DECLARE accountid INT ;
DECLARE totalBal DOUBLE DEFAULT 0;
DECLARE totaldays INT DEFAULT 0;
-- DECLARE intrestrate INT DEFAULT 0.07;
DECLARE regdate DATE ;

SELECT id,registereddate,balance INTO accountid,regdate,totalBal FROM accounts WHERE acctnumber=accountnumber;


SELECT DATEDIFF(CURDATE(),regdate) INTO totaldays;

IF totaldays > 365 THEN
SET totalBal=totalBal+totalBal*0.07;

UPDATE accounts SET balance=totalBal WHERE id=accountid;
END IF;
END $$
DELIMITER ;



CALL claculateIntrest('67675456546');
-- SELECT @idacct,@b,@total,@rdate;



SELECT DATEDIFF(CURDATE(),"2022-04-21") ;

SELECT registereddate,balance FROM accounts WHERE acctnumber='67675456546';
SELECT registereddate,balance,id  FROM accounts WHERE acctnumber='67675456546';
SELECT id FROM accounts WHERE acctnumber='67675456546';

UPDATE accounts SET balance=999 WHERE acctnumber='67675456546';


