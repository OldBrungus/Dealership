CREATE PROCEDURE dbo.SubmitRequest
	@email nvarchar(255) = NULL,
	@name nvarchar(255),
	@phoneNumber nvarchar(255) = NULL,
	@message nvarchar(max)
AS

	INSERT INTO dbo.ContactRequest (Email, [Name], PhoneNumber, CreateDate, [Message])
	VALUES (@email, @name, @phoneNumber, GETDATE(), @message)