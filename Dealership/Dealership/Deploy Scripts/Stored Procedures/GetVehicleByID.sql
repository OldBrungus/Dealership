CREATE PROCEDURE dbo.GetVehicleByID
	@vehicleID INT
AS
	SELECT
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
	WHERE ID = @vehicleID