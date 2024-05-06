CREATE DATABASE CarRental
--Dont Submit Create Database
CREATE TABLE Categories(
[Id] INT PRIMARY KEY,
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] DECIMAL(3,2),
[WeeklyRate] DECIMAL(3,2),
[MonthlyRate] DECIMAL(3,2),
[WeekendRate] DECIMAL(3,2)
)

INSERT INTO Categories(Id,CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES      (1,'Sport',2.42,1.12,3.33,NULL),
              (2,'Regular',4.33,3.11,4.33,2.52),
			   (3,'Sport-Extreme',2.12,1.83,5.00,NULL)

CREATE TABLE Cars(
[Id] INT PRIMARY KEY,
[PlateNumber] INT NOT NULL,
[Manufacturer] NVARCHAR(50) NOT NULL,
[Model] NVARCHAR(50) NOT NULL,
[CarYear] INT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
[Doors] TINYINT,
[Picture] VARBINARY(MAX),
[Condition] NVARCHAR(10),
[Available] CHAR(1) NOT NULL,
CHECK([Available] = 'Y' OR [Available] = 'N' )
)

INSERT INTO Cars(Id,PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available)
VALUES          (1,12231,'Mazda','M6',2009,1,NULL,NULL,'Good','N'),
                (2,1998,'Audi','A8',2020,2,NULL,NULL,'Good','Y'),
				(3,2231,'VW','Arteon',2010,3,NULL,NULL,'Bad','Y')
				
CREATE TABLE Employees(
[Id] INT PRIMARY KEY,
[FirstName] NVARCHAR(50) NOT NULL,
[LastName] NVARCHAR(50) NOT NULL,
[Title] NVARCHAR(20) NOT NULL,
[Notes] NVARCHAR(20) 
)

INSERT INTO Employees(Id,FirstName,LastName,Title,Notes)
VALUES          (1,'Teodor','Valchev','Engineer','King'),
                 (2,'Elenka','Buba','Art','Queen'),
				  (3,'Denosliv','Stamenaa','Child',NULL)

CREATE TABLE Customers(
[Id] INT PRIMARY KEY,
[DriverLicenceNumber] INT NOT NULL,
[FullName] NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
[City] NVARCHAR(20) NOT NULL,
[ZIPCode] INT NOT NULL,
[Notes] NVARCHAR(20)
)

INSERT INTO Customers(Id,DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
VALUES          (1,22234,'Ivan Valchev','lipa 2','Haskovo',2231,NULL),
                 (2,1298,'Buba Valcheva','ili 2','Haskovo',2244,NULL),
				  (3,4423,'Demkata Valchev','dunav 2','Stara Zagora',2902,NULL)

CREATE TABLE RentalOrders(
[Id] INT PRIMARY KEY,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
[CarId] INT FOREIGN KEY REFERENCES Cars(Id),
[TankLevel] INT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT NOT NULL,
[StartDate] DATETIME2,
[EndDate] DATETIME2,
[TotalDays] TINYINT,
[RateApplied] INT,
[TaxRate] INT,
[OrderStatus] CHAR(3),
CHECK([OrderStatus] = 'ON' OR [OrderStatus] = 'OFF'),
[Notes] NVARCHAR(20)
)

INSERT INTO RentalOrders(Id,EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes)
VALUES          (1,1,1,1,50,400,400,800,'2000-05-18','2000-05-20',2,NULL,NULL,'ON',NULL),
                (2,2,2,2,50,400,400,800,'2000-05-18','2000-05-20',2,NULL,NULL,'ON',NULL),
                (3,3,3,3,70,500,200,700,'2000-05-02','2000-05-10',8,NULL,NULL,'OFF',NULL)