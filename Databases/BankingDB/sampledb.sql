/* don't change sequence of any records*/
INSERT INTO customers(id,customerid,dependancyid,usertype) VALUES(1,1,1,"corporation");
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(2,2,"corporation");
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(3,3,"corporation");
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(4,4,"corporation");
INSERT INTO customers(id,customerid,dependancyid,usertype) VALUES(5,5,7,"corporation"); 
INSERT INTO customers(id,customerid,dependancyid,usertype) VALUES(6,6,6,"corporation");
INSERT INTO customers(id,customerid,dependancyid,usertype) VALUES(7,7,2,"person");  
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(8,3,"person");
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(9,4,"person");
INSERT INTO customers(customerid,dependancyid,usertype) VALUES(10,5,"person");
SELECT * FROM customers;
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546601','business','MAHB0000286',200000,'2023-03-01',1);
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('39025546612','savings','BARBO0000286',225700,'2023-03-04',2);        
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('12656767876','savings','AXIS0000296',2352500,'2021-07-01',3);   
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('67675456546','savings','AXIS0000296',789000,'2021-06-01',4); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('45656577687','business','AXIS0000296',2352500,'2022-03-11',5); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('46556565566','business','AXIS0000296',2352500,'2022-04-21',6); 
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('56423234233','savings','AXIS0000296',2352500,'2021-11-11',7);
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('56423234234','savings','BARBO0000286',2352500,'2021-11-11',1);
INSERT INTO accounts(acctnumber,accttype,ifsccode,balance,registereddate,customerid)VALUES('56423234235','savings','AXIS0000296',2352500,'2021-11-11',1);
SELECT * FROM accounts;

INSERT INTO loan(loanid,amount,loansanctiondate,duration,intrestrate,acctId)VALUES(100,'100000','2023-09-08',15,11.58,3);
INSERT INTO loan(amount,loansanctiondate,duration,intrestrate,acctId)VALUES('50000','2023-01-31',15,11.58,6);
INSERT INTO loan(amount,loansanctiondate,duration,intrestrate,acctId)VALUES('75000','2023-03-25',15,15.23,4);
SELECT * FROM loan;

show tables;
