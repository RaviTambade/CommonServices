-- Active: 1688103921885@@127.0.0.1@3306@bankingdb

SELECT * FROM customers;
select * from accounts;
SELECT @transactionId;
SELECT * FROM operations;
SELECT * FROM transactions;
SELECT * FROM accounts;
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",1000,@transactionId);

SELECT acctnumber,ifsccode from accounts 
JOIN customers ON accounts.customerid = customers.customerid
WHERE customers.usertype="corporation" AND customers.dependancyid=1;