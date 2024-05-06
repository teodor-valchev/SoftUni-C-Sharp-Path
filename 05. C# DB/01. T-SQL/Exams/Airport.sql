CREATE TABLE Passengers
(
	Id INT IDENTITY PRIMARY KEY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT IDENTITY PRIMARY KEY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT IDENTITY PRIMARY KEY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT IDENTITY PRIMARY KEY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations 
(
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)


-- Problem 03

UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'C' OR Condition = 'B') AND (FlightHours IS NULL OR FlightHours <=100)  AND ([Year]>=2013)

--Problem 04

DELETE FROM Passengers
WHERE LEN(FullName) <= 10

-- Problem 6

SELECT p.FirstName,p.LastName,a.Manufacturer,a.Model,a.FlightHours 
FROM Pilots AS p
JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
 JOIN Aircraft AS a ON a.Id = pa.AircraftId
 WHERE a.FlightHours IS NOT NULL  AND a.FlightHours < 304
 ORDER BY a.FlightHours DESC,p.FirstName

 -- Problem 07

 SELECT TOP(20) 
	fd.Id DestinationId,
	[Start],
	p.FullName,
	a.AirportName,
	fd.TicketPrice
FROM FlightDestinations fd
JOIN Passengers p ON fd.PassengerId = p.Id
JOIN Airports a ON fd.AirportId = a.Id
WHERE DAY([Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName




CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT
AS 
BEGIN
	DECLARE @flightsNumber INT;
	SET @flightsNumber = (SELECT COUNT(p.Id) FROM Passengers p JOIN FlightDestinations fd ON p.Id = fd.PassengerId WHERE Email LIKE @email)
	RETURN @flightsNumber
	
	
END