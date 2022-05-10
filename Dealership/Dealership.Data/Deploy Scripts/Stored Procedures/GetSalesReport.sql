CREATE PROCEDURE dbo.GetSalesReport
	@startDate DATETIME = NULL,
	@endDate DATETIME = NULL
AS

	SELECT Count(*) AS TotalSalesCount, SUM(SalePrice) AS TotalSalesAmount
	FROM Vehicle
	WHERE Sold = 1
	AND (@startDate IS NULL 
		OR (SaleDate >= @startDate)) 
	AND (@endDate IS NULL 
		OR (SaleDate <= @endDate))

