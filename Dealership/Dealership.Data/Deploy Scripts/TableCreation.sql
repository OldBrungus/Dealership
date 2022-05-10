-- Resource Tables --
CREATE TABLE dbo.BodyStyle
(
	BodyStyleID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BodyStyle NVARCHAR(255) NOT NULL
)

CREATE TABLE dbo.TransmissionType
(
	TransmissionTypeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TransmissionType NVARCHAR(255) NOT NULL
)

CREATE TABLE dbo.Color
(
	ColorID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Color NVARCHAR(255) NOT NULL
)

CREATE TABLE dbo.Interior
(
	InteriorID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Interior NVARCHAR(255) NOT NULL
)

CREATE TABLE dbo.Make
(
	MakeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Make NVARCHAR(255) NOT NULL,
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedOn DATETIME NOT NULL
)


CREATE TABLE dbo.Model
(
	ModelID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Model NVARCHAR(255) NOT NULL,
	MakeID INT FOREIGN KEY (MakeID) REFERENCES dbo.Make (MakeID),
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedOn DATETIME NOT NULL
)


-- End Resource Tables --

-- Vehicle --
CREATE TABLE dbo.Vehicle
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Featured BIT NOT NULL DEFAULT(0),
	VIN NVARCHAR(17) NULL,
	[Year] NVARCHAR(4) NULL,
	BodyStyleID INT NOT NULL,
		FOREIGN KEY (BodyStyleID) REFERENCES dbo.BodyStyle (BodyStyleID),
	TransmissionTypeID INT NOT NULL,
		FOREIGN KEY (TransmissionTypeID) REFERENCES dbo.TransmissionType (TransmissionTypeID),
	ColorID INT NOT NULL,
		FOREIGN KEY (ColorID) REFERENCES dbo.Color (ColorID),
	InteriorID INT NOT NULL,
		FOREIGN KEY (InteriorID) REFERENCES dbo.Interior (InteriorID),
	SalePrice INT NOT NULL,
	MSRP INT NOT NULL,
	[New] BIT NOT NULL DEFAULT (0),
	[Description] NVARCHAR(255) NULL,
	Mileage INT NOT NULL,
	Picture VARBINARY(MAX) NULL,
	MakeID INT NOT NULL,
		FOREIGN KEY (MakeID) REFERENCES dbo.Make (MakeID),
	ModelID INT NOT NULL,
		FOREIGN KEY (ModelID) REFERENCES dbo.Model (ModelID),
	Sold BIT NOT NULL DEFAULT (0),
	SaleDate DATETIME NULL
)

-- End Vehicle --

-- Contact Tables --
CREATE TABLE dbo.ContactRequest
(
	ContactRequestID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Email nvarchar(255),
	[Name] nvarchar(255),
	PhoneNumber nvarchar(255),
	CreateDate datetime,
	[Message] nvarchar(max)
)

-- End Contact --

-- Specials --
CREATE TABLE dbo.Special
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(MAX),
	[Description] NVARCHAR(MAX)
)
-- End Specials --

-- User Tables --
CREATE TABLE dbo.[User]
(
	UserID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(255),
	LastName NVARCHAR(255),
	Email NVARCHAR(255),
	RoleName NVARCHAR(255)
)

-- End User --

-- Purchase Tables --
CREATE TABLE Purchase
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(255),
	Phone NVARCHAR(255),
	Email NVARCHAR(255),
	Street1 NVARCHAR(255),
	Street2 NVARCHAR(255),
	City NVARCHAR(255),
	[State] NVARCHAR(255),
	Zip NVARCHAR(255),
	PurchasePrice NVARCHAR(255),
	PurchaseType NVARCHAR(255)
)

CREATE TABLE PurchaseType
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	PurchaseTypeName NVARCHAR(255)
)

CREATE TABLE [State]
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	StateName NVARCHAR(255) NOT NULL,
	StateAbbreviation NVARCHAR(2) NOT NULL
)