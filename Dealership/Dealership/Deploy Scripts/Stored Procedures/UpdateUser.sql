CREATE PROCEDURE dbo.UpdateUser
	@userID UNIQUEIDENTIFIER,
	@firstName NVARCHAR(255),
	@lastName NVARCHAR(255),
	@email NVARCHAR(255)
AS
	UPDATE dbo.[User]
	SET FirstName = @firstName,
		LastName = @lastName,
		Email = @email
	WHERE @userID = UserID