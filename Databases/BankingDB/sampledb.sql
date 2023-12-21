-- Active: 1696576841746@@127.0.0.1@3306@bankingdb
/* don't change sequence of any records*/
INSERT INTO customers(bankcustomerid,usertype) VALUES(1,"C");
INSERT INTO customers(bankcustomerid,usertype) VALUES(2,"C");
INSERT INTO customers(bankcustomerid,usertype) VALUES(3,"C");
INSERT INTO customers(bankcustomerid,usertype) VALUES(4,"C");
INSERT INTO customers(bankcustomerid,usertype) VALUES(5,"C"); 
INSERT INTO customers(bankcustomerid,usertype) VALUES(6,"C");
INSERT INTO customers(bankcustomerid,usertype) VALUES(1,"I");  
INSERT INTO customers(bankcustomerid,usertype) VALUES(2,"I");-- Insert records from customerid 9 to 46
INSERT INTO customers (bankcustomerid, usertype) VALUES (3, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (4, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (5, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (6, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (7, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (8, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (9, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (10, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (11, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (12, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (13, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (14, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (15, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (16, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (17, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (18, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (19, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (20, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (21, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (22, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (23, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (24, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (25, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (26, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (27, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (28, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (29, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (30, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (31, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (32, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (33, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (34, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (35, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (36, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (37, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (38, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (39, "I");
INSERT INTO customers (bankcustomerid, usertype) VALUES (40, "I");

INSERT INTO customers(bankcustomerid,usertype) VALUES(14,"C");-- run this query at last


INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546601','business','MAHB0000286',200000,'2022-03-01',1);
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546612','business','BARBO0000286',225700,'2022-03-04',2);        
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('12656767876','business','AXIS0000296',2352500,'2021-07-01',3);   
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('67675456546','business','AXIS0000296',789000,'2021-06-01',4); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('45656577687','business','AXIS0000296',2352500,'2022-03-11',5); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('46556565566','business','AXIS0000296',2352500,'2022-04-21',6); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('56423234233','savings','AXIS0000296',2352500,'2021-11-11',7);
INSERT INTO accounts(acctnumber, accttype, ifsccode, balance, registereddate, customerid) VALUES
('9999999999', 'savings', 'SBI0000123', 32000, '2022-11-19', 8),
('7777777777', 'savings', 'AXIS0000456', 65000, '2022-12-31', 9),
('1234432112', 'savings', 'HDFC0000234', 10000, '2021-01-05', 10),
('5555666677', 'savings', 'ICICI0000345', 42000, '2021-02-18', 11),
('7777888899', 'savings', 'SBI0000456', 58000, '2021-03-31', 12),
('9999888877', 'savings', 'AXIS0000567', 72000, '2021-05-13', 13),
('4444333322', 'savings', 'HDFC0000789', 89000, '2021-06-25', 14),
('2222111133', 'savings', 'ICICI0000789', 32000, '2021-08-07', 15),
('8888999911', 'savings', 'SBI0000567', 65000, '2021-09-20', 16),
('7777666655', 'savings', 'AXIS0000789', 78000, '2021-10-02', 17),
('1111000011', 'savings', 'HDFC0000678', 45000, '2021-11-14', 18),
('5555777788', 'savings', 'ICICI0000456', 96000, '2021-12-27', 19),
('6666555577', 'savings', 'SBI0000789', 52000, '2022-02-09', 20),
('9999111122', 'savings', 'AXIS0000890', 78000, '2022-03-23', 21),
('2222888899', 'savings', 'HDFC0000789', 38000, '2022-05-05', 22),
('4444666677', 'savings', 'ICICI0000890', 49000, '2022-06-17', 23),
('7777555566', 'savings', 'SBI0000678', 62000, '2022-07-30', 24),
('8888000011', 'savings', 'AXIS0000789', 57000, '2022-09-11', 25),
('1111999922', 'savings', 'HDFC0000789', 85000, '2022-10-24', 26),
('5555444433', 'savings', 'ICICI0000789', 42000, '2022-12-06', 27),
('2222666677', 'savings', 'SBI0000789', 96000, '2022-01-18', 28),
('7777666677', 'savings', 'AXIS0000789', 52000, '2022-02-01', 29),
('9999444433', 'savings', 'HDFC0000789', 78000, '2022-03-15', 30),
('1111444455', 'savings', 'ICICI0000789', 49000, '2022-04-27', 31),
('5555111122', 'savings', 'SBI0000789', 62000, '2022-06-09', 32),
('8888333344', 'savings', 'AXIS0000789', 57000, '2022-07-22', 33),
('4444666677', 'savings', 'HDFC0000789', 85000, '2022-09-03', 34),
('2222444455', 'savings', 'ICICI0000789', 42000, '2022-10-16', 35),
('5555777788', 'savings', 'SBI0000789', 96000, '2022-11-28', 36),
('7777666655', 'savings', 'AXIS0000789', 52000, '2022-01-10', 37),
('9999111122', 'savings', 'HDFC0000789', 78000, '2022-02-22', 38),
('1111000011', 'savings', 'ICICI0000789', 49000, '2022-04-05', 39),
('5555444433', 'savings', 'SBI0000789', 62000, '2022-05-18', 40),
('2222333344', 'savings', 'AXIS0000789', 57000, '2022-06-30', 41),
('4444555566', 'savings', 'HDFC0000789', 85000, '2022-08-12', 42),
('7777666677', 'savings', 'ICICI0000789', 42000, '2022-09-24', 43),
('9999444433', 'savings', 'SBI0000789', 96000, '2022-11-06', 44),
('1111444455', 'savings', 'AXIS0000789', 52000, '2022-12-19', 45);

INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('123456789','business','AXIS0000999',200000000,'1975-01-01',47);

INSERT INTO loanapplications(applicationid,applicationdate,loanamount,loanduration,accountid,loantypeid)VALUES(11,'2023-08-11',500000,10,1,100);
INSERT INTO loanapplications(applicationid,applicationdate,loanamount,loanduration,accountid,loantypeid)VALUES(12,'2023-08-11',8900000,15,6,100);
INSERT INTO loanapplications(applicationdate,loanamount,loanduration,accountid,loantypeid)VALUES
('2023-10-25',500000,10,1,100),
('2023-11-30',100000,15,2,101),
('2023-01-25',750000,17,3,102),
('2023-02-09',850000,20,4,100);




INSERT INTO loan(loansanctiondate,emiamount,applicationid)VALUES('2023-09-08',9321,11);



INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(3,12656767876,9321,'2023-10-10','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,9321,'2023-10-25','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-01-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-01-15','D',"EMI");

INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-02-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-02-15','D',"EMI");

INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-03-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-03-15','D',"EMI");

INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-04-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-04-15','D',"EMI");

INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-05-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-05-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-06-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-06-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-07-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-07-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-08-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-08-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-09-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-09-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-10-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-10-15','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(6,46556565566,5510,'2023-11-15','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,5510,'2023-11-15','D',"EMI");

INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-04-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-04-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-05-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-05-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-06-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-06-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-07-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-07-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-08-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-08-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-09-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-09-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-10-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-10-5','D',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(4,67675456546,90013,'2023-11-5','W',"EMI");
INSERT INTO operations(acctId,acctnumber,amount,operationdate,operationmode,operationtype)VALUES(46,123456789,90013,'2023-11-5','D',"EMI");


INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(15,16,'2023-10-10');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(17,18,'2023-01-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(19,20,'2023-02-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(21,22,'2023-03-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(23,24,'2023-04-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(25,26,'2023-05-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(27,28,'2023-06-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(29,30,'2023-07-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(31,32,'2023-08-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(33,34,'2023-09-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(35,36,'2023-10-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(37,38,'2023-11-15');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(39,40,'2023-04-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(41,42,'2023-05-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(43,44,'2023-06-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(45,46,'2023-07-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(47,48,'2023-08-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(49,50,'2023-09-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(51,52,'2023-10-05');
INSERT INTO transactions(fromoperationid,tooperationid,transactiondate)VALUES(53,54,'2023-11-05');


INSERT INTO loantype(loantype,intrestrate)VALUES('home',9.5);
INSERT INTO loantype(loantype,intrestrate)VALUES('personal',11.0);
INSERT INTO loantype(loantype,intrestrate)VALUES('car',12.5);
INSERT INTO loantype(loantype,intrestrate)VALUES('education',7.6);
INSERT INTO loantype(loantype,intrestrate)VALUES('bussiness',15.6);


