CREATE PROCEDURE dbo.AddMake
	@displayName NVARCHAR(255),
	@createdBy NVARCHAR(255)
AS
	INSERT INTO dbo.Make (Make, CreatedBy, CreatedOn)
	VALUES (@displayName, @createdBy, GETDATE())