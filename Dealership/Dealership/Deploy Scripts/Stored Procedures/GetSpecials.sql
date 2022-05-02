CREATE PROCEDURE dbo.GetSpecials
AS
	SELECT ID, Title, [Description]
	from dbo.Special