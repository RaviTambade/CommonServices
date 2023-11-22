-- Active: 1678359546568@@127.0.0.1@3306@bankingdb



select * from customers;

select * from accounts;
SELECT @transactionId;
SELECT * FROM operations;

SELECT * FROM transactions;
SELECT * FROM accounts;
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",1000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",2000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",3000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",4000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",5000,@transactionId);
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",6000,@transactionId);

CALL claculateIntrest('67675456546');



SELECT acctnumber,ifsccode from accounts 
JOIN customers ON accounts.customerid = customers.customerid
WHERE customers.usertype="corporation" AND customers.dependancyid=1;

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

