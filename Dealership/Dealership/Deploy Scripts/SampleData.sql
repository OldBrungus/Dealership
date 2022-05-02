
-- Sample Resources --

INSERT INTO BodyStyle (BodyStyle)
VALUES
('Car'),
('Truck'),
('SUV')

INSERT INTO Color (Color)
VALUES
('Red'),
('Blue'),
('Yellow'),
('Black'),
('White'),
('Silver')

INSERT INTO Interior (Interior)
VALUES
('Black'),
('Tan')

INSERT INTO Make (Make)
VALUES
('Ford'),
('Toyota'),
('Subaru')

INSERT INTO Model (Model, MakeID)
VALUES
('Fusion', 1),
('86', 2),
('WRX', 3)

INSERT INTO TransmissionType (TransmissionType)
VALUES
('Manual'),
('Automatic')

-- End Sample Resources --

-- Sample Vehicles --

INSERT INTO Vehicle 
(Featured, 
VIN, 
[Year], 
BodyStyleID, 
TransmissionTypeID, 
ColorID, 
InteriorID, 
SalePrice, 
MSRP,
New, 
[Description],
Mileage, 
--Picture, todo
MakeID, 
ModelID)
VALUES 
(1, '12345678901234567', '1999', 1, 1, 1, 1, 99999, 19999, 0, 'Doper than hell', 15000, 1, 1)

-- End Sample Vehicles --

-- Sample Sales --

Insert Into PurchaseType
VALUES 
('Bank Finance'),
('Cash'),
('Dealer Finance')

-- End Sales --

-- States --
INSERT INTO [State]
VALUES
('Alabama', 'AL'),
('Alaska', 'AK'),
('Arizona', 'AZ'),
('Arkansas', 'AR'),
('California', 'CA'),
('Colorado', 'CO'),
('Connecticut', 'CT'),
('Delaware', 'DE'),
('Florida', 'FL'),
('Georgia', 'GA'),
('Hawaii', 'HI'),
('Idaho', 'ID'),
('Illinois', 'IL'),
('Indiana', 'IN'),
('Iowa', 'IA'),
('Kansas', 'KS'),
('Kentucky', 'KY'),
('Louisiana', 'LA'),
('Maine', 'ME'),
('Maryland', 'MD'),
('Massachusetts', 'MA'),
('Michigan', 'MI'),
('Minnesota', 'MN'),
('Mississippi', 'MS'),
('Missouri', 'MO'),
('Montana', 'MT'),
('Nebraska', 'NE'),
('Nevada', 'NV'),
('New Hampshire', 'NH'),
('New Jersey', 'NJ'),
('New Mexico', 'NM'),
('New York', 'NY'),
('North Carolina', 'NC'),
('North Dakota', 'ND'),
('Ohio', 'OH'),
('Oklahoma', 'OK'),
('Oregon', 'OR'),
('Pennsylvaia', 'PA'),
('Rhode Island', 'RI'),
('South Carolina', 'SC'),
('South Dakota', 'SD'),
('Tennessee', 'TN'),
('Texas', 'TX'),
('Utah', 'UT'),
('Vermont', 'VT'),
('Virginia', 'VI'),
('Washington', 'WA'),
('West Virginia', 'WV'),
('Wisconson', 'WI'),
('Wyoming', 'WY')

-- End States --
