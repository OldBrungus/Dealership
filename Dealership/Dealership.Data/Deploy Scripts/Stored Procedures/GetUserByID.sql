CREATE PROCEDURE dbo.GetUserByID
	@userID UNIQUEIDENTIFIER
AS
	SELECT * FROM dbo.[User]
	WHERE UserID = @userID