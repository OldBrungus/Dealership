CREATE PROCEDURE dbo.PurchaseVehicle
	@vehicleID INT,
	@name NVARCHAR(255),
	@phone NVARCHAR(255) = NULL,
	@email NVARCHAR(255) = NULL,
	@street1 NVARCHAR(255),
	@street2 NVARCHAR(255) = NULL,
	@city NVARCHAR(255),
	@state NVARCHAR(255),
	@zip NVARCHAR(255),
	@purchasePrice NVARCHAR(255),
	@purchaseType NVARCHAR(255)
AS
	INSERT INTO dbo.Purchase
	VALUES
		(@name,
		@phone,
		@email,
		@street1,
		@street2,
		@city,
		@state,
		@zip,
		@purchasePrice,
		@purchaseType)

	UPDATE dbo.Vehicle
	SET Sold = 1
	WHERE ID = @vehicleID