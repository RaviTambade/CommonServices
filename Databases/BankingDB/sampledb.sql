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

INSERT INTO loanapplicants(applicatid,accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(1,3,'2023-08-11','AFD67550',1000000,'business','approved');
INSERT INTO loanapplicants(accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(6,'2022-12-11','JHG6753',5000000,'business','approved');
INSERT INTO loanapplicants(accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(4,'2023-02-5','KLM67551',7500000,'business','approved');
INSERT INTO loanapplicants(accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(8,'2021-08-1','ZXC6755',2000000,'home','approved');
INSERT INTO loanapplicants(accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(9,'2019-12-15','KLT6756',3000000,'home','approved');
INSERT INTO loanapplicants(accountid,applydate,panid,loanamount,loantype,loanstatus)VALUES(10,'2015-1-15','ERT6757',400000,'home','approved');

INSERT INTO loan(loanid,amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES(1,'1000000','2023-09-08',15,10,9321,9.5,3);
INSERT INTO loan(amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES('5000000','2023-01-31',15,15,56516,10.9,6);
INSERT INTO loan(amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES('7500000','2023-03-25',15,5,90013,12.00,4);

INSERT INTO loan(amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES('2000000','2021-09-09',20,10,17356,8.5,8);
INSERT INTO loan(amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES('3000000','2020-01-31',12,15,35679,9.9,9);
INSERT INTO loan(amount,loansanctiondate,duration,emiday,emiamount,intrestrate,acctId)VALUES('400000','2015-03-25',10,5,5510,11.00,10);

