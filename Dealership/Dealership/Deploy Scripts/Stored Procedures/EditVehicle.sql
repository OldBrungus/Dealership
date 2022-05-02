﻿CREATE PROCEDURE dbo.EditVehicle
	@ID INT,
	@makeID INT,
	@modelID INT,
	@new BIT,
	@bodyStyleID INT,
	@year NVARCHAR(4),
	@transmissionTypeID INT,
	@colorID INT,
	@interiorID INT,
	@mileage INT,
	@vin NVARCHAR(17),
	@msrp INT,
	@salePrice INT,
	@description NVARCHAR(255),
	@picture VARBINARY(MAX),
	@isFeatured BIT
AS
	UPDATE dbo.Vehicle
	SET
		MakeID = @makeID,
		ModelID = @modelID,
		New = @new,
		BodyStyleID = @bodyStyleID,
		[Year] = @year,
		TransmissionTypeID = @transmissionTypeID,
		ColorID = @colorID,
		InteriorID = @interiorID,
		Mileage = @mileage,
		VIN = @vin,
		MSRP = @msrp,
		SalePrice = @salePrice,
		[Description] = @description,
		Picture = @picture,
		Featured = @isFeatured
	WHERE
		@ID = ID