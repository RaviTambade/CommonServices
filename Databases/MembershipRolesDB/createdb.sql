-- Active: 1694968636816@@127.0.0.1@3306@membershipprofilesdb
DROP DATABASE IF EXISTS MembershipProfilesDB;
CREATE DATABASE  MembershipProfilesDB;
USE MembershipProfilesDB;
CREATE TABLE credentials(id INT PRIMARY KEY AUTO_INCREMENT,
                         contactnumber  VARCHAR(15) UNIQUE,
                         password VARCHAR(25), 
                         createdon DATETIME DEFAULT CURRENT_TIMESTAMP,
                         modifiedon DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP);


CREATE TABLE users(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     imageurl VARCHAR(50),
                     aadharid VARCHAR(30) NOT NULL UNIQUE,
                     firstname VARCHAR(50),
                     lastname VARCHAR(50),
                     birthdate DATE,
                     gender VARCHAR(40),
                     email VARCHAR(40),
                     contactnumber VARCHAR(40));
                     

CREATE TABLE addresses (
                        id INT PRIMARY KEY AUTO_INCREMENT,
						userid INT,constraint fk_users_address foreign key(userid) references users(id) on update cascade on delete cascade,
                        area  varchar(50) NOT NULL,    
                        landmark varchar(50),
                        city varchar(20) NOT NULL,
                        state varchar(20) NOT NULL,
                        alternatecontactnumber varchar(20),
						pincode varchar(10) NOT NULL);



CREATE TABLE
        roles(
            id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
            name varchar(20),
            lob varchar(20)
        );

    CREATE TABLE
        userroles(
            id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
            userid INT NOT NULL,
            roleid INT NOT NULL,
            CONSTRAINT uc_userroles UNIQUE (userid, roleid),
            CONSTRAINT fk_userroles_roles FOREIGN KEY(roleid) REFERENCES roles(id) ON UPDATE CASCADE ON DELETE CASCADE,
            CONSTRAINT fk_userroles_users FOREIGN KEY(userid) REFERENCES users(id) ON UPDATE CASCADE ON DELETE CASCADE
        );

   