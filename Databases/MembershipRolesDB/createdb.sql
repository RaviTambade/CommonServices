-- Active: 1707123530557@@127.0.0.1@3306@membershiprolesdb

DROP DATABASE IF EXISTS MembershipRolesDB;
CREATE DATABASE  MembershipRolesDB;
USE MembershipRolesDB;

CREATE TABLE users( id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     imageurl VARCHAR(50),
                     aadharid VARCHAR(30) NOT NULL UNIQUE,
                     firstname VARCHAR(50),
                     lastname VARCHAR(50),
                     birthdate DATE,
                     gender ENUM("male", "female") NOT NULL,
                     email VARCHAR(40),
                     contactnumber VARCHAR(40),
                     password VARCHAR(25),  
                     createdon DATETIME DEFAULT CURRENT_TIMESTAMP,
                     modifiedon DATETIME DEFAULT CURRENT_TIMESTAMP);
                     

CREATE TABLE addresses (
                        id INT PRIMARY KEY AUTO_INCREMENT,
						userid INT,constraint fk_users_address foreign key(userid) references users(id) on update cascade on delete cascade,
                        area  varchar(50) NOT NULL,    
                        landmark varchar(50) NOT NULL,
                        city varchar(20) NOT NULL,
                        state varchar(30) NOT NULL,
						pincode varchar(10) NOT NULL,
                        addresstype enum("Residential","Official","Billing"));



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

   