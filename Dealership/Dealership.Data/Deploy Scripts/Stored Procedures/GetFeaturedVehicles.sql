CREATE PROCEDURE dbo.GetFeaturedVehicles
AS
	SELECT TOP 8 ID, [Year], Make, Model, SalePrice, Picture 
	FROM Vehicle
	JOIN Make ON Make.MakeID = Vehicle.MakeID
	JOIN Model ON Model.ModelID = Vehicle.ModelID
	WHERE Featured = 1
	AND Sold = 0