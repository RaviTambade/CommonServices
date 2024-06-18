-- Active: 1696576841746@@127.0.0.1@3306@membershiprolesdb
show tables;
use membershiprolesdb;
select * from users;
SELECT * FROM roles;
select * from addresses;
select * from userroles;

-- Roles defined for specific lob
select * FROM roles where lob="PMS";
select * FROM roles where lob="Inventory Management";
select * FROM roles where lob="banking";

-- Roles assignes for specific user
select * from userroles where userid = 1;

select users.firstname ,users.lastname ,roles.name,roles.lob
from users 
inner join userroles
on users.id=userroles.userid
inner join roles
on userroles.roleid=roles.id
where userid =1;

-- Users assigned for for specific role 
select * from userroles where roleid = 1;

select users.firstname ,users.lastname ,roles.name,roles.lob
from users 
inner join userroles
on users.id=userroles.userid
inner join roles
on userroles.roleid=roles.id
where roleid =19;

-- User details according to lob
select users.firstname ,users.lastname,roles.lob
from users 
inner join userroles
on users.id=userroles.userid
inner join roles
on userroles.roleid=roles.id
where lob ="banking";

-- User count for lob
select count(roles.lob) as NumberOfUsers
from users 
inner join userroles
on users.id=userroles.userid
inner join roles
on userroles.roleid=roles.id
where lob ="banking";

-- Address details for user
select * from addresses where userid = 1;


--Users With Given Contact Number & Password
 SELECT * FROM users WHERE contactnumber=@contactNumber AND BINARY password=@password;

 --this query returned users who have the role specified by roleName
  select * from users inner join userroles on users.id=userroles.userid inner join roles on roles.id=userroles.roleid where roles.name=@roleName;

--this query returns all the info related to that user id
   select id,firstname,lastname,imageurl,aadharid,birthdate,gender,email,contactnumber from users where id IN (1);