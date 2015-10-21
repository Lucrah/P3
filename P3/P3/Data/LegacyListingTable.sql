USE [C:\USERS\KRISTOFFERM\DOCUMENTS\GITHUB\P3\P3\P3\P3\DATA\P3DB.MDF]
CREATE TABLE [dbo].[LegacyDataTable]
(
	[Size]           NVARCHAR (50)          NULL,
    [Rooms]          NVARCHAR (50) NULL,
    [Type]           NVARCHAR (50) NULL,
    [YearBuilt]      NVARCHAR (50) NULL,
    [BuySum]         NVARCHAR (50) NULL,
    [DateOfSale/SaleType]   NVARCHAR (50)          NULL,
    [KRMNumber]          NVARCHAR (50)         NULL,
    [RoomNumberAgain]        NVARCHAR (50)          NULL,
    [SizeAgain]        NVARCHAR (4000) NULL,
	[Address/ZipCode/City]    NVARCHAR(4000) NULL,
)
GO