SELECT *,
      111.045* DEGREES(ACOS(COS(RADIANS(latpoint))
                 * COS(RADIANS(Lat))
                 * COS(RADIANS(longpoint) - RADIANS(Lng))
                 + SIN(RADIANS(latpoint))
                 * SIN(RADIANS(Lat))))*1000 AS distance_in_m 
 FROM address
 JOIN (
     SELECT  57.068097000000000  AS latpoint,  10.128560000000000 AS longpoint
   ) AS p ON 1=1 
   JOIN( listings l, salesinfo s) where address.IDAddress = l.IDListings AND address.IDAddress = s.IDSalesInfo AND l.PropertyType = 'Lejlighed' having distance_in_m < 5000 
    
order by distance_in_m 															#De argumenter vi skal bruge, kan indsættes i denne where clause