-- Active: 1696576841746@@127.0.0.1@3306@bankingdb
DROP PROCEDURE IF EXISTS fundtransfer;

DROP PROCEDURE IF EXISTS emitransfer;
DELIMITER $$
CREATE PROCEDURE fundtransfer(IN fromaccountnumber VARCHAR(20),IN toaccountnumber VARCHAR(20),
                             IN fromifsccode VARCHAR(20),IN toifsccode VARCHAR(20),
                             IN amount DOUBLE,IN transactiontype VARCHAR(20),OUT transactionId INT)
BEGIN
DECLARE fromaccountid INT DEFAULT 0;
DECLARE toaccountid INT DEFAULT 0;
DECLARE fromoperationid INT DEFAULT 0;
DECLARE tooperationid INT DEFAULT 0;
DECLARE fromaccountbalance DOUBLE DEFAULT 0;
DECLARE toaccountbalance DOUBLE DEFAULT 0;
SELECT id,balance INTO fromaccountid,fromaccountbalance FROM accounts WHERE  acctnumber=fromaccountnumber AND ifsccode=fromifsccode;

SELECT id,balance INTO toaccountid,toaccountbalance FROM accounts WHERE  acctnumber=toaccountnumber AND ifsccode =toifsccode;    

INSERT INTO operations(acctId,acctnumber,amount,operationmode,operationtype,operationdate)
VALUES(fromaccountid,fromaccountnumber,amount,'W',transactiontype,NOW());
SET fromoperationid=LAST_INSERT_ID();
UPDATE accounts SET balance=round(fromaccountbalance-amount,2) WHERE id=fromaccountid;
INSERT INTO operations(acctId,acctnumber,amount,operationmode,operationtype,operationdate)
VALUES(toaccountid,toaccountnumber,amount,'D',transactiontype,NOW());
SET tooperationid=LAST_INSERT_ID();
UPDATE accounts SET balance=round(toaccountbalance+amount,2) WHERE id=toaccountid;
INSERT INTO transactions (fromoperationid,tooperationid) VALUES (fromoperationid,tooperationid);
SET transactionId=LAST_INSERT_ID();
END $$ 
DELIMITER ; 


DROP PROCEDURE  IF EXISTS claculateIntrest;

DELIMITER $$
CREATE PROCEDURE claculateIntrest(IN accountnumber VARCHAR(20) ,OUT transid INT)
BEGIN
DECLARE accountid INT ;
DECLARE totalBal DOUBLE DEFAULT 0;
DECLARE totaldays INT DEFAULT 0;
DECLARE intrestamount DOUBLE DEFAULT 0;
DECLARE regdate DATE ;
DECLARE toifsccode VARCHAR(20) ;
DECLARE bankIfsccode VARCHAR(20) ;

SELECT id,registereddate,balance,ifsccode INTO accountid,regdate,totalBal,toifsccode 
FROM accounts WHERE acctnumber=accountnumber;
SELECT ifsccode INTO bankifsccode FROM accounts WHERE acctnumber='123456789';
-- SET ifscone=bankifsccode;
-- SET ifsctwo=toifsccode;
SELECT DATEDIFF(CURDATE(),regdate) INTO totaldays;
IF totaldays > 365 THEN
SET intrestamount=round(totalBal*0.07,2);
SET totalBal=round(totalBal+totalBal*0.07,2);
UPDATE accounts SET balance=totalBal WHERE id=accountid;
-- SET amount=intrestamount;

CALL fundtransfer ('123456789',accountnumber,bankifsccode,toifsccode,intrestamount,"Interest",transid );

END IF ;
END $$
DELIMITER ;


CALL claculateIntrest('67675456546',@transid);
SELECT @transid;

DROP PROCEDURE  IF EXISTS emitransfer;

DELIMITER $$
CREATE PROCEDURE emitransfer(IN accountnumber VARCHAR(20) ,OUT transid INT)
BEGIN
DECLARE accountid INT ;
DECLARE totalBal DOUBLE DEFAULT 0;

DECLARE loanId INT ;
DECLARE emi double ;
DECLARE fromifsccode VARCHAR(20) ;
DECLARE bankIfsccode VARCHAR(20) ;

SELECT id,balance,ifsccode INTO accountid,totalBal,fromifsccode 
FROM accounts WHERE acctnumber=accountnumber;
SELECT ifsccode INTO bankifsccode FROM accounts WHERE acctnumber='123456789';
-- SELECT loanid,emiamount INTO loanId,emi FROM loan WHERE acctId = accountid;
SELECT  loan.loanid,loan.emiamount INTO loanId,emi FROM loan 
inner join loanapplications on
loanapplications.id = loan.applicationid WHERE loanapplications.accountid = accountid ;

CALL fundtransfer (accountnumber,'123456789',fromifsccode,bankifsccode,emi,'EMI',transid);

END $$
DELIMITER ;

CALL emitransfer('7777777777',@transid);
CALL emitransfer('67675456546',@transid);
CALL emitransfer('9999999999',@transid);
CALL emitransfer('1234432112',@transid);
CALL emitransfer('12656767876',@transid);
CALL emitransfer('46556565566',@transid);

SELECT @transid;

DROP PROCEDURE  IF EXISTS loanstatus;

DELIMITER $$
CREATE PROCEDURE loanstatus(IN lID INT,OUT Ramount DOUBLE,OUT RemainingEmi INT,OUT TotalInstllments INT)
BEGIN

DECLARE accountnumber VARCHAR(20) ;
DECLARE accountID INT;
DECLARE totalemipaid double default 0.00;
DECLARE loanamount double;
DECLARE remaingemicount INT;
DECLARE cnt INT;
DECLARE loansactiondate date;

SELECT amount,loansanctiondate,duration,acctId INTO loanamount,loansactiondate,remaingemicount,accountID FROM loan where loanid = lID;
select acctnumber INTO accountnumber from accounts where id = accountID;
SELECT SUM(amount) ,count(operationdate) INTO totalemipaid,cnt from operations where operationmode="W" and operationtype="EMI" and acctnumber=accountnumber;


SET remaingemicount = remaingemicount * 12;
SET TotalInstllments = remaingemicount;
SET Ramount = loanamount - totalemipaid;
SET RemainingEmi = remaingemicount - cnt;

END $$
DELIMITER ;

CALL loanstatus(6,@Ramount,@RemainingEmi,@TotalInstllments);
SELECT @Ramount,@RemainingEmi,@TotalInstllments;








