
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
--Picture,
MakeID, 
ModelID)
VALUES 
(1, '12345678901234567', '1999', 1, 1, 1, 1, 5000, 6000, 0, '*shrugs* It runs', 150000, 1, 1),
(1, '1a2s3d4f5q6w7e8w7', '2000', 1, 2, 2, 1, 6000, 7000, 0, 'Take it or leave it', 110000, 1, 1),
(1, 'x1s1d22d2s5gf5v2z', '1987', 1, 1, 5, 1, 17000, 18000, 0, 'The ultimate drift machine', 200000, 2, 2),
(1, '8djfh47gfj3jf8cj3', '2022', 1, 1, 2, 2, 45000, 46000, 1, 'Ooh rally car, very nice', 128, 3, 3)

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
('Wisconsin', 'WI'),
('Wyoming', 'WY')

-- End States --

-- Begin Specials --

INSERT INTO Special
VALUES
('Hot Deal', '$5000 extra BONUS CASH on any new purchase'),
('Sweet Savings', 'DOUBLE YOUR TRADE IN VALUE!!!'),
('An Offer You Cant Refuse', 'Free gun with every purchase')
