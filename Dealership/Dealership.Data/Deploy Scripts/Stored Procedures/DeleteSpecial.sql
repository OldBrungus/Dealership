CREATE PROCEDURE dbo.DeleteSpecial
	@id int
AS
	DELETE FROM dbo.Special
	WHERE Special.ID = @id