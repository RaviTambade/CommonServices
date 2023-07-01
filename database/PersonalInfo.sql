-- Active: 1678339848098@@127.0.0.1@3306@personaldetails
DROP DATABASE IF EXISTS personaldetails;
CREATE DATABASE personaldetails;
USE personaldetails;

CREATE TABLE peoples(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     aadharid VARCHAR(30) NOT NULL UNIQUE,
                     firstname VARCHAR(50),
                     lastname VARCHAR(50),
                     birthdate DATE,
                     gender VARCHAR(40),
                     email VARCHAR(40),
                     contactnumber VARCHAR(40));
                     
CREATE TABLE  addresses (id INT PRIMARY KEY AUTO_INCREMENT,
						personid int,constraint fk_person_id foreign key(personid) references peoples(id) on update cascade on delete cascade,
						longitude varchar(30),
                        latitude varchar(30),
                        landmark varchar(30),
						pincode varchar(30));
                     
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("580408011566","Pragati","Bangar","2000-12-18","Female","bangarpragati11@gmail.com","7498035692");
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("580408011562","Abhay","Navale","2000-12-08","male","navaleabhay11@gmail.com","9075966080");
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("58040801153","Akash","Ajab","2000-12-28","male","ajabakash11@gmail.com","9881571268");


insert into addresses(personid,longitude, latitude, landmark, pincode)values (1, "9.595334","18.535317","bazar peth", "415612" );
insert into addresses(personid,longitude, latitude, landmark, pincode)values (2, "9.595334","18.535317","Rest House", "412452" );
insert into addresses(personid,longitude, latitude, landmark, pincode)values (3, "9.595334","18.535317","Taj Hotel", "521411" );
insert into addresses(personid,longitude, latitude, landmark, pincode)values (3, "9.595334","18.535317","Taj BeautiParal", "521418" );

SELECT * FROM peoples;
SELECT * FROM addresses;