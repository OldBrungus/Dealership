CREATE PROCEDURE dbo.GetVehicles
	@searchTerm NVARCHAR(MAX) = NULL,
	@minYear INT,
	@maxYear INT = NULL,
	@minPrice INT,
	@maxPrice INT = NULL
AS
	SELECT TOP 20
	Vehicle.BodyStyleID, 
	BodyStyle, 
	Vehicle.ColorID, 
	Color,
	[Description],
	Featured,
	ID,
	Vehicle.InteriorID,
	Interior,
	Vehicle.MakeID,
	Make,
	Mileage,
	Vehicle.ModelID,
	Model,
	MSRP,
	New,
	Picture,
	SalePrice,
	Vehicle.TransmissionTypeID,
	TransmissionType,
	VIN,
	[Year]
	FROM Vehicle
	JOIN BodyStyle ON BodyStyle.BodyStyleID = Vehicle.BodyStyleID
	JOIN Color ON Color.ColorID = Vehicle.ColorID
	JOIN Interior ON Interior.InteriorID = Vehicle.InteriorID
	JOIN Make ON Make.MakeID = Vehicle.MakeID
	JOIN Model ON Model.ModelID = Vehicle.ModelID
	JOIN TransmissionType ON TransmissionType.TransmissionTypeID = Vehicle.TransmissionTypeID
	WHERE Sold = 0
	AND (@searchTerm IS NULL 
		OR Make LIKE @searchTerm
		OR Model LIKE @searchTerm
		OR [Year] LIKE @searchTerm)
	AND CAST([Year] AS INT) >= @minYear
	AND (@maxYear IS NULL
		OR CAST([Year] AS INT) <= @maxYear)
	AND SalePrice >= @minPrice
	AND (@maxPrice IS NULL
		OR SalePrice <= @maxPrice)