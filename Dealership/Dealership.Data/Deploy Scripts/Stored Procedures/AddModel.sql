CREATE PROCEDURE dbo.AddModel
	@modelName NVARCHAR(255),
	@makeID INT,
	@createdBy NVARCHAR(255)
AS
	INSERT INTO dbo.Model (Model, MakeID, CreatedBy, CreatedOn)
	VALUES (@modelName, @makeID, @createdBy, GETDATE())