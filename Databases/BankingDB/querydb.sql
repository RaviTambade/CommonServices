-- Active: 1678359546568@@127.0.0.1@3306@bankingdb
SELECT * FROM customers;
SELECT * FROM accounts;
SELECT * FROM transactions;
SELECT * FROM operations;
SELECT * FROM loanapplicants;
--  delete from  loanapplicants where applicatid = 11;

SELECT * FROM loan;
SELECT @transactionId;
-- DROP table customers;
-- DROP table accounts;
-- DROP table loanapplicants;

SELECT * FROM loanapplicants 
WHERE applydate >= '2023-01-01' 
AND applydate <= '2023-11-30';


SELECT * FROM loanapplicants WHERE applydate >= '2023-01-01' AND applydate <= '2023-11-30';

SELECT * FROM loanapplicants 
WHERE loanstatus = "applied";

SELECT * FROM loanapplicants 
WHERE loanstatus = "approved";

 UPDATE loanapplicants SET loanstatus = "approved" WHERE applicatid=8;


CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",1000,"Interest",@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",2000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",3000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",4000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",5000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",6000,@transactionId);

CALL claculateIntrest('7777777777',@transid);
CALL claculateIntrest('67675456546',@transid);
SELECT @transid;


show tables;

SELECT acctnumber,ifsccode from accounts 
JOIN customers ON accounts.customerid = customers.customerid
WHERE customers.usertype="corporation" AND customers.dependancyid=1;


SELECT amount  FROM loan where loanid = 1;

SELECT SUM(amount) from operations where operationmode="W" and operationtype="EMI" and acctnumber="12656767876";

SELECT count(operationdate) from operations where operationmode="W" and operationtype="EMI" and acctnumber="46556565566";

SELECT loanapplicants.* ,customers.bankcustomerid,customers.usertype from loanapplicants 
inner join accounts on loanapplicants.accountid = accounts.id inner join customers on accounts.customerid = customers.id; 

SELECT loanapplicants.* ,customers.bankcustomerid,customers.usertype from loanapplicants 
inner join accounts on loanapplicants.accountid = accounts.id inner join customers on accounts.customerid = customers.id
WHERE loanstatus = "applied";

SELECT operations.acctnumber,operations.amount,operations.operationdate  from operations 
inner join accounts on operations.acctId = accounts.id 
where accounts.id = (Select acctId from loan where loanid = 2) AND operations.operationtype = "EMI"; 



SELECT o.operationid,o.amount,o.operationdate,o.operationmode,
    CASE
    WHEN t.fromoperationid = o.operationid THEN CONCAT('Sent to ', a_to.acctnumber)
    WHEN t.tooperationid = o.operationid THEN CONCAT('Received from ',a_from.acctnumber)
    ELSE ''
    END AS description,(SELECT SUM(
                        CASE   
                        WHEN o2.operationmode = 'D' THEN o2.amount
                        WHEN o2.operationmode = 'W' THEN - o2.amount
                        ELSE 0
                        END
                        )
        FROM operations o2
        WHERE o2.acctId = o.acctId
        AND (
            o2.operationid <= o.operationid
            )
        ) AS balance
FROM operations o
    JOIN accounts a ON o.acctId = a.id
    LEFT JOIN transactions t ON t.fromoperationid = o.operationid OR t.tooperationid = o.operationid
    LEFT JOIN operations o_from ON t.fromoperationid = o_from.operationid
    LEFT JOIN operations o_to ON t.tooperationid = o_to.operationid
    LEFT JOIN accounts a_from ON o_from.acctId = a_from.id
    LEFT JOIN accounts a_to ON o_to.acctId = a_to.id
WHERE
    a.acctnumber ="39025546612"
ORDER BY
    o.operationdate,
    o.operationid;
    END ;
    
DROP PROCEDURE bankStatement;
SELECT o.operationid, a.acctnumber, o.amount, o.operationdate, o.operationmode,
       (
           SELECT SUM(
               CASE
                   WHEN o2.operationmode = 'D' THEN o2.amount
                   WHEN o2.operationmode = 'W' THEN -o2.amount
                   ELSE 0
               END
           )
           FROM operations o2
           WHERE o2.acctId = o.acctId AND (o2.operationid <= o.operationid)
       )
        AS balance
FROM operations o
JOIN accounts a ON o.acctId = a.id
WHERE a.acctnumber = '45656577687'
ORDER BY o.operationdate, o.operationid;


SELECT acctnumber,ifsccode from accounts
                 JOIN customers ON accounts.customerid = customers.customerid
                 WHERE customers.dependancyid=2 AND customers.usertype='corporation';

Drop table installment;
Drop table loanorder;
drop table loan;