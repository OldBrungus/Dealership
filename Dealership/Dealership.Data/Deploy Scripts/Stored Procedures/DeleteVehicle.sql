CREATE PROCEDURE dbo.DeleteVehicle
	@id INT
AS
	DELETE FROM Vehicle
	WHERE @id = ID