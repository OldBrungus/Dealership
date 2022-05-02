CREATE PROCEDURE dbo.AddMake
	@displayName NVARCHAR(255)
AS
	INSERT INTO dbo.Make (Make)
	VALUES (@displayName)