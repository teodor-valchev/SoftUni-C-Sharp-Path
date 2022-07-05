CREATE TABLE CreateSoftUni.dbo.Towns
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(MAX)
)
CREATE TABLE CreateSoftUni.dbo.Addresses
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AddressText NVARCHAR(MAX) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES CreateSoftUni.dbo.Towns(Id)
)
CREATE TABLE CreateSoftUni.dbo.Departments
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(MAX)
)
CREATE TABLE CreateSoftUni.dbo.Employees
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	JobTitle NVARCHAR(MAX) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES CreateSoftUni.dbo.Departments(Id),
	HireDate DATE,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES CreateSoftUni.dbo.Addresses(Id)
)
