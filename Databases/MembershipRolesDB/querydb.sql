-- Active: 1696576841746@@127.0.0.1@3306@membershiprolesdb
show tables;

use membershiprolesdb;

select * from users;

SELECT * FROM roles;

select * from addresses;

select * from userroles;

-- Roles defined for specific lob
select * FROM roles where lob = "PMS";

select * FROM roles where lob = "Inventory Management";

select * FROM roles where lob = "banking";

-- Roles assignes for specific user
select * from userroles where userid = 1;

select users.firstname, users.lastname, roles.name, roles.lob
from users
    inner join userroles on users.id = userroles.userid
    inner join roles on userroles.roleid = roles.id
where
    userid = 5;

-- Users assigned for for specific role
select * from userroles where roleid = 1;

select users.firstname, users.lastname, roles.name, roles.lob
from users
    inner join userroles on users.id = userroles.userid
    inner join roles on userroles.roleid = roles.id
where
    roleid = 15;

-- User details according to lob
select users.firstname, users.lastname, roles.lob
from users
    inner join userroles on users.id = userroles.userid
    inner join roles on userroles.roleid = roles.id
where
    lob = "banking";

-- User count for lob
select count(roles.lob) as NumberOfUsers
from users
    inner join userroles on users.id = userroles.userid
    inner join roles on userroles.roleid = roles.id
where
    lob = "banking";

-- Address details for user
select * from addresses where userid = 1;

-- Users With Given Contact Number & Password
SELECT *
FROM users
WHERE
    contactnumber = @contactNumber
    AND BINARY password = @password;

-- this query returned users who have the role specified by roleName
select *
from users
    inner join userroles on users.id = userroles.userid
    inner join roles on roles.id = userroles.roleid
where
    roles.name = @roleName;

-- this query returns all the info related to that user id
select
    id,
    firstname,
    lastname,
    imageurl,
    aadharid,
    birthdate,
    gender,
    email,
    contactnumber
from users
where
    id IN (1);

-- Insert New User In the user table
Insert Into
    users (
        imageurl,
        aadharid,
        firstname,
        lastname,
        birthdate,
        gender,
        email,
        contactnumber,
        password,
        createdon,
        modifiedon
    )
Values (
        @imageurl,
        @aadharId,
        @firstName,
        @lastName,
        @birthDate,
        @gender,
        @email,
        @contactNumber,
        @password,
        @createdOn,
        @modifiedOn
    );

-- This query updates the specified table
Update users
set
    aadharid = @aadharId,
    imageurl = @imageUrl,
    firstname = @firstName,
    lastname = @lastName,
    birthdate = @birthDate,
    gender = @gender,
    email = @email
where
    id = @Id;

-- Update old contact number to new contact number
UPDATE users
SET
    contactnumber = @newContactNumber
WHERE
    password = @password
    AND contactnumber = @oldContactNumber;

-- Update old password to new password
UPDATE users
SET password = @newPassword
WHERE
    password = @oldpassword
    AND contactnumber = @contactNumber;
    
-- Get user details according to lob and role
select users.id,users.imageurl,users.aadharid,users.firstname,users.lastname,users.birthdate,users.gender,users.email,users.contactnumber,users.createdon,users.modifiedon
from users
inner join userroles on users.id = userroles.userid
inner join roles on userroles.roleid = roles.id
where roles.name = "farmer" AND roles.lob = "EAgro";


    