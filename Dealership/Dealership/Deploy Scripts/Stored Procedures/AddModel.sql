CREATE PROCEDURE dbo.AddModel
	@modelName NVARCHAR(255),
	@makeID INT
AS
	INSERT INTO dbo.Model (Model, MakeID)
	VALUES (@modelName, @makeID)