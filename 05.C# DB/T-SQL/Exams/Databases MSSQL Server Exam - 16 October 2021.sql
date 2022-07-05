CREATE DATABASE CigarShop
--Problem 01
CREATE TABLE Sizes(
Id INT PRIMARY KEY IDENTITY,
[Length] INT NOT NULL
CHECK ([Length]  BETWEEN 10 AND 25),
RingRange DECIMAL(6,2) NOT NULL,
CHECK (RingRange  BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes(
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) NOT NULL UNIQUE,
BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar DECIMAL(8,2) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)



CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId  INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars(
ClientId INT FOREIGN KEY REFERENCES Clients(Id),
CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
PRIMARY KEY(ClientId,CigarId)
)

--Problem 02

INSERT INTO Cigars(CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL)
VALUES   ('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
         ('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
		 ('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
		 ('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
		 ('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')


INSERT INTO Addresses(Town,Country,Streat,ZIP)
VALUES ('Sofia','Bulgaria','18 Bul. Vasil levski',1000),
       ('Athens','Greece','4342 McDonald Avenue',10435),
	   ('Zagreb','Croatia','4333 Lauren Drive',10000)

--Problem 03

UPDATE Cigars
SET PriceForSingleCigar+= PriceForSingleCigar*0.2
SELECT *   FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
JOIN Brands AS b ON c.BrandId = b.Id
WHERE TasteType = 'Spicy'  

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--Problem 04
DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Country, 1) LIKE 'C')

DELETE FROM Addresses
WHERE LEFT(Country, 1) LIKE 'C'

-- Problem 5
SELECT CigarName,PriceForSingleCigar,ImageURL 
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC



-- Problem 6
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength 
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

--Problem 7

SELECT Id, CONCAT(FirstName, ' ', LastName)ClientName, Email FROM Clients
WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName

--Problem 8
SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL 
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE 
s.[Length] >= 12 AND (c.CigarName LIKE '%ci%'
	OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName,c.PriceForSingleCigar DESC

-- Problem 09
SELECT 
	CONCAT(cl.FirstName, ' ', cl.LastName)FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(c.PriceForSingleCigar))CigarPrice
FROM Clients cl
JOIN Addresses a ON cl.AddressId = a.Id
JOIN ClientsCigars cc ON cl.Id = cc.ClientId
JOIN Cigars c ON cc.CigarId = c.Id
WHERE a.ZIP NOT LIKE '%[^0-9.]%'
GROUP BY FirstName, LastName, a.Id, a.Country, a.ZIP
ORDER BY FullName

--Problem 10
SELECT
	cl.LastName,
	AVG(s.[Length])CigarLength,
	CEILING(AVG(s.RingRange))CigarRingRange
FROM Clients cl
JOIN ClientsCigars cc ON cl.Id = cc.ClientId
JOIN Cigars c ON c.Id = cc.CigarId
JOIN Sizes s ON c.SizeId = s.Id
WHERE cl.Id IN (SELECT cc.ClientId FROM ClientsCigars)
GROUP BY cl.LastName
ORDER BY CigarLength DESC

-- Problem 11

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(MAX))
RETURNS INT
AS 
BEGIN
	DECLARE @countOfCigars INT;
	SET @countOfCigars =
	(SELECT 
		COUNT(*) 
	FROM Clients cl
	JOIN ClientsCigars cc ON cc.ClientId = cl.Id
	JOIN Cigars c ON cc.CigarId = c.Id
	WHERE cl.FirstName LIKE 'Betty')
	RETURN @countOfCigars
END













