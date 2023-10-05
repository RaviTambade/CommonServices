-- Active: 1682349138553@@127.0.0.1@3306@usersdb
DELIMITER //

CREATE FUNCTION CalculateDistanceByAddress(
    addressid1 INT,
    addressid2 INT
) RETURNS  DECIMAL(10,4)
DETERMINISTIC
BEGIN
    DECLARE lat1 DOUBLE;
    DECLARE lon1 DOUBLE;
    DECLARE lat2 DOUBLE;
    DECLARE lon2 DOUBLE;
    
    DECLARE R DOUBLE;
    DECLARE dlat DOUBLE;
    DECLARE dlon DOUBLE;
    DECLARE a DOUBLE;
    DECLARE c DOUBLE;
  
    SELECT latitude, longitude INTO lat1, lon1
    FROM indiapincodes
    WHERE pincode = (SELECT pincode from addresses WHERE id= addressid1) LIMIT 1;

    SELECT latitude, longitude INTO lat2, lon2
    FROM indiapincodes
    WHERE pincode = (SELECT pincode from addresses WHERE id= addressid2) LIMIT 1;

    IF lat1 IS NULL OR lon1 IS NULL OR lat2 IS NULL OR lon2 IS NULL THEN
        RETURN NULL;
    END IF;

    SET R = 6371; -- Earth's radius in kilometers
    --  Haversine formula. 
    SET dlat = RADIANS(lat2 - lat1);
    SET dlon = RADIANS(lon2 - lon1);

    SET a = SIN(dlat/2) * SIN(dlat/2) + COS(RADIANS(lat1)) * COS(RADIANS(lat2)) * SIN(dlon/2) * SIN(dlon/2);
    SET c = 2 * ATAN2(SQRT(a), SQRT(1 - a));
    RETURN R * c ; -- Distance in kilometers
END;
//

DELIMITER ;
 -- DROP Function CalculateDistanceByAddress;
SELECT CalculateDistanceByAddress('1', '5') AS distance_in_km;
explain SELECT * FROM indiapincodes WHERE pincode='410503';

SELECT id AS addressid,pincode,CalculateDistanceByAddress(2, id) AS distance
FROM addresses WHERE id IN (3,1,4,5);

