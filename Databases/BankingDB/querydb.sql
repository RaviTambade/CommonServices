

select * from accounts;
SELECT @transactionId;
SELECT * FROM operations;

SELECT * FROM transactions;
SELECT * FROM accounts;
CALL fundtransfer("39025546601","39025546612","MAHB0000286" ,"BARBO0000286",1000,@transactionId);

