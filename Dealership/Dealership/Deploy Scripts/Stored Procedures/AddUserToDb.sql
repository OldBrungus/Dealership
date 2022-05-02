CREATE PROCEDURE dbo.AddUserToDb
	@Id UNIQUEIDENTIFIER,
	@firstName NVARCHAR(255),
	@lastName NVARCHAR(255),
	@email NVARCHAR(255),
	@roleName NVARCHAR(255)
AS
	INSERT INTO dbo.[User] (UserID, FirstName, LastName, Email, RoleName)
	VALUES (@Id, @firstName, @lastName, @email, @roleName)