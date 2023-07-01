CREATE DATABASE personaldetails;

use personaldetails;

CREATE TABLE peoples(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     aadharid VARCHAR(30) NOT NULL UNIQUE,
                     firstname VARCHAR(50),
                     lastname VARCHAR(50),
                     birthdate DATE,
                     gender VARCHAR(40),
                     email VARCHAR(40),
                     contactnumber VARCHAR(40));
                     
                     
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("580408011566","Pragati","Bangar","2000-12-18","Female","bangarpragati11@gmail.com","7498035692");
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("580408011562","Abhay","Navale","2000-12-08","male","navaleabhay11@gmail.com","9075966080");
INSERT INTO peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) VALUES("58040801153","Akash","Ajab","2000-12-28","male","ajabakash11@gmail.com","9881571268");