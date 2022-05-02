CREATE PROCEDURE dbo.AddSpecial
	@title nvarchar(max),
	@description nvarchar(max)
AS
	INSERT INTO dbo.Special (Title, [Description])
	VALUES (@title, @description)