UPDATE credentials SET password='12345678' WHERE id=5;
SELECT * FROM credentials;

SELECT EXISTS(SELECT * FROM credentials WHERE contactnumber='8530728589' AND password='12345678');