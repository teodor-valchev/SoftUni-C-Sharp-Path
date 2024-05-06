CREATE TABLE Owners(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT PRIMARY KEY IDENTITY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT PRIMARY KEY IDENTITY,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)


CREATE TABLE AnimalsCages(
CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
PRIMARY KEY (CageId,AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT PRIMARY KEY IDENTITY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)


--Problem 02
INSERT INTO Volunteers([Name],PhoneNumber,[Address],AnimalId,DepartmentId)
     VALUES ('Anita Kostova','0896365412','Sofia, 5 Rosa str.',	15,	1),
	        ('Dimitur Stoev','0877564223',NULL,	42,	4),
			('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',	9,7),
			('Stoyan Tomov','0898564100','Montana, 1 Bor str.',	18,8),
			('Boryana Mileva','0888112233',NULL,	31,	5)
	         

INSERT INTO Animals([Name],	BirthDate,	OwnerId, AnimalTypeId)
     VALUES ('Giraffe','2018-09-21',21,1),
	        ('Harpy Eagle','2015-04-17',15,3),
			('Hamadryas Baboon','2017-11-02',NULL,1),
			('Tuatara','2021-06-30',2,4)
			
-- Problem 03
UPDATE  Animals
SET OwnerId = 4
FROM Animals
WHERE OwnerId IS NULL

--Problem 04

DELETE FROM  Volunteers 
wHERE DepartmentId = 2

DELETE FROM  VolunteersDepartments 
wHERE DepartmentName = 'Education program assistant'

--Problem 05
SELECT [Name],[PhoneNumber],[Address],[AnimalId],[DepartmentId]
FROM Volunteers
ORDER BY [Name],AnimalId,DepartmentId

--Problem 06

SELECT animaleee.[Name],
       tipe.AnimalType,
FORMAT (animaleee.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS [animaleee]
JOIN AnimalTypes AS [tipe] ON animaleee.AnimalTypeId = tipe.id 
ORDER BY [Name]

--Problem 07
SELECT TOP(5) oosa.[Name],
COUNT(anoha.[Name]) AS CountOfAnimals
FROM Animals AS anoha
JOIN Owners AS oosa ON anoha.OwnerId = oosa.Id
GROUP BY oosa.Name
ORDER BY CountOfAnimals DESC

--Problem 08
SELECT 
CONCAT(o.[Name],'-',a.[Name]) AS OwnersAnimals,
      o.PhoneNumber,
	  ac.CageId
FROM Animals as a
JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
JOIN Owners AS o ON o.Id = a.OwnerId
WHERE a.AnimalTypeId = 1
ORDER BY o.[Name],a.[Name]DESC


--Problem 09
SELECT volu.[Name],volu.PhoneNumber,SUBSTRING(volu.[Address],7,LEN(volu.[Address])) AS [Address]
FROM Volunteers AS volu
JOIN VolunteersDepartments AS vsde ON volu.DepartmentId = vsde.Id
WHERE vsde.Id = 2 AND volu.[Address] LIKE '%Sofia%'
ORDER BY volu.[Name]



-- Problem 10
SELECT anii.[Name],DATEPART(YEAR,anii.BirthDate) AS BirthYear,tipos.AnimalType
--DATEDIFF(year, '01/01/2022', anii.BirthDate) AS DateDiff
FROM Animals as anii
JOIN AnimalTypes AS tipos ON anii.AnimalTypeId = tipos.Id
WHERE OwnerId IS NULL AND DATEDIFF(year, '01/01/2022', anii.BirthDate) >-5 AND  tipos.AnimalType <> 'Birds'
ORDER BY anii.[Name]


--Problem 11

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(max))
RETURNS INT
AS
BEGIN
   DECLARE @DepartmenId INT = (
		SELECT Id
		FROM VolunteersDepartments
		WHERE DepartmentName = @VolunteersDepartment
		)

		DECLARE @departmenstCount INT = (
		SELECT COUNT(Id)
		FROM Volunteers
		WHERE DepartmentId = @DepartmenId
		
		)
   
    RETURN @departmenstCount

END
--Problem 12
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(MAX)) 
AS
BEGIN
DECLARE @HASoWNER VARCHAR

SET @HASoWNER = ( SELECT a.[Name],CONCAT(owne.Name,'') AS OwnersName
  FROM Animals AS a
 full OUTER JOIN Owners as owne ON a.OwnerId = owne.Id
 WHERE a.[Name] = @AnimalName)
 IF(@HASoWNER IS NULL)
 BEGIN

 END
 
END

SELECT * FROM Volunteers
SELECT * FROM VolunteersDepartments
SELECT * FROM Animals
SELECT * FROM Cages
SELECT * FROM AnimalsCages
SELECT* from AnimalTypes



