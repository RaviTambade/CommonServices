-- Active: 1696576841746@@127.0.0.1@3306@bankingdb
/* don't change sequence of any records*/
INSERT INTO customers(id,customerid,dependencyid,usertype) VALUES(1,1,1,"corporation");
INSERT INTO customers(customerid,dependencyid,usertype) VALUES(2,2,"corporation");
INSERT INTO customers(customerid,dependencyid,usertype) VALUES(3,3,"corporation");
INSERT INTO customers(customerid,dependencyid,usertype) VALUES(4,4,"corporation");
INSERT INTO customers(id,customerid,dependencyid,usertype) VALUES(5,5,7,"corporation"); 
INSERT INTO customers(id,customerid,dependencyid,usertype) VALUES(6,6,6,"corporation");
INSERT INTO customers(id,customerid,dependencyid,usertype) VALUES(7,7,1,"person");  
INSERT INTO customers(customerid,dependencyid,usertype) VALUES(8,2,"person");-- Insert records from customerid 9 to 46
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (9, 3, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (10, 4, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (11, 5, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (12, 6, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (13, 7, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (14, 8, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (15, 9, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (16, 10, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (17, 11, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (18, 12, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (19, 13, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (20, 14, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (21, 15, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (22, 16, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (23, 17, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (24, 18, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (25, 19, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (26, 20, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (27, 21, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (28, 22, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (29, 23, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (30, 24, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (31, 25, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (32, 26, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (33, 27, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (34, 28, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (35, 29, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (36, 30, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (37, 31, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (38, 32, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (39, 33, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (40, 34, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (41, 35, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (42, 36, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (43, 37, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (44, 38, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (45, 39, "person");
INSERT INTO customers (customerid, dependencyid, usertype) VALUES (46, 40, "person");


INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546601','business','MAHB0000286',200000,'2022-03-01',1);
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546612','savings','BARBO0000286',225700,'2022-03-04',2);        
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('12656767876','savings','AXIS0000296',2352500,'2021-07-01',3);   
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('67675456546','savings','AXIS0000296',789000,'2021-06-01',4); 
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


INSERT INTO loan(loanid,amount,loansanctiondate,duration,intrestrate,acctId)VALUES(100,'100000','2023-09-08',15,11.58,3);
INSERT INTO loan(amount,loansanctiondate,duration,intrestrate,acctId)VALUES('50000','2023-01-31',15,11.58,6);
INSERT INTO loan(amount,loansanctiondate,duration,intrestrate,acctId)VALUES('75000','2023-03-25',15,15.23,4);
