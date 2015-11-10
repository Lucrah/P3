LOAD DATA INFILE 'c:/ProgramData/MySQL/MySQL Server 5.7/Uploads/DBListings.csv' 
INTO TABLE listings
FIELDS TERMINATED BY ';' 
LINES TERMINATED BY '\n'
