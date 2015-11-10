LOAD DATA INFILE 'c:/ProgramData/MySQL/MySQL Server 5.7/Uploads/DBSalesInfoSold.csv' 
INTO TABLE salesinfosold
FIELDS TERMINATED BY ';' 
LINES TERMINATED BY '\n'
(IDSalesInfoSold, SalesType, Price, PriceSqr, @SalesDate)
SET SalesDate = STR_TO_DATE(@SalesDate, '%d-%m-%Y')