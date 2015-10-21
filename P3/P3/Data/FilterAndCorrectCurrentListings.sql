USE [C:\USERS\KRISTOFFERM\DOCUMENTS\GITHUB\P3\P3\P3\P3\DATA\P3DB.MDF]
GO
BULK INSERT [dbo].[CurrentListings]
FROM 'C:\Users\KristofferM\Documents\GitHub\P3\P3\P3\P3\Data\til salg 20th Oct 00_33.csv'
WITH
(
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO

UPDATE CurrentListings SET Size = REPLACE(Size, 'm-¦', '')
UPDATE CurrentListings SET PropertySize = REPLACE(PropertySize, 'm-¦', '')
UPDATE CurrentListings SET PricePrKVM = REPLACE(PricePrKVM, '.', '')
UPDATE CurrentListings SET Price = REPLACE(Price, '.', '')

ALTER TABLE CurrentListings ALTER COLUMN YearBuilt INT
ALTER TABLE CurrentListings ALTER COLUMN Size INT
ALTER TABLE CurrentListings ALTER COLUMN PricePrKVM INT
ALTER TABLE CurrentListings ALTER COLUMN Price INT
ALTER TABLE CurrentListings ALTER COLUMN PropertySize INT
ALTER TABLE CurrentListings ALTER COLUMN Rooms INT
ALTER TABLE CurrentListings ALTER COLUMN ZipCode INT



