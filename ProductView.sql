USE [AdventureWorks2012]
GO

/****** Object:  View [dbo].[Product]    Script Date: 6/8/2017 1:12:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Product]
AS
SELECT ProductID, Name, ProductNumber, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice
FROM     Production.Product


GO
