CREATE PROCEDURE dbo.GetInventoryReportRows
AS
	SELECT 
	SUM(MSRP) AS StockValue,
	COUNT(*) AS [Count],
	[Year],
	Make AS MakeName,
	Model AS ModelName,
	New
	FROM Vehicle
	JOIN Make on Make.MakeID = Vehicle.MakeID
	JOIN Model on Model.ModelID = Vehicle.ModelID
	GROUP BY [Year], Make.Make, Model.Model, New