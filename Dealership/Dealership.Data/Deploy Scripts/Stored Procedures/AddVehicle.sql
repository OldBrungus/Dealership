CREATE PROCEDURE dbo.AddVehicle
	@make INT,
	@model INT,
	@new BIT,
	@bodyStyle INT,
	@year NVARCHAR(4),
	@transmission INT,
	@color INT,
	@interior INT,
	@mileage INT,
	@vin NVARCHAR(17),
	@msrp INT,
	@salePrice INT,
	@description NVARCHAR(255),
	@picture VARBINARY(MAX),
	@featured BIT
AS
	INSERT INTO dbo.Vehicle (Featured, VIN, [Year], BodyStyleID, TransmissionTypeID, ColorID, InteriorID,
	 SalePrice, MSRP, New, [Description], Mileage, Picture, MakeID, ModelID)
	 VALUES (0, @vin, @year, @bodyStyle, @transmission, @color, @interior, @salePrice, @msrp, @new, @description,
	  @mileage, @picture, @make, @model)

	SELECT SCOPE_IDENTITY()