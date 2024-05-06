--Problem 01
 SELECT * 
 FROM Departments

--Problem 02
 SELECT [Name] 
 FROM Departments

--Problem 03
 SELECT [FirstName],[LastName],[Salary]  
 FROM Employees

--Problem 04
 SELECT [FirstName],[MiddleName],[LastName] 
 FROM Employees

--Problem 05
 SELECT  CONCAT([FirstName],'.',[LastName],'@','softuni.bg') AS [Full Email Address]
 FROM Employees

--Problem 06
 SELECT DISTINCT[Salary]
 FROM Employees

--Problem 07
 SELECT DISTINCT[Salary]
 FROM Employees

--Problem 08
 SELECT *
 FROM Employees
  WHERE [JobTitle] = 'Sales Representative'

--Problem 09
  SELECT [FirstName],[LastName],[JobTitle]
  FROM Employees
  WHERE [Salary] BETWEEN 20000 AND 30000

--Problem 10
  SELECT CONCAT([FirstName],' ',[MiddleName], ' ',[LastName])
  AS  [Full Name]
  FROM Employees
  WHERE [Salary] IN(25000, 14000, 12500,23600)

 --Problem 11
  SELECT [FirstName],[LastName]
  FROM Employees
  WHERE [ManagerID] IS NULL

--Problem 12
  SELECT [FirstName],[LastName],[Salary]
  FROM Employees
  WHERE  [Salary] > 50000
  ORDER BY [Salary] DESC

 --Problem 13
  SELECT TOP(5) [FirstName],[LastName]
  FROM Employees
  WHERE  [Salary] > 50000
  ORDER BY [Salary] DESC

 --Problem 14
  SELECT [FirstName],[LastName]
  FROM Employees
  WHERE NOT [DepartmentID]= 4

--Problem 15
   SELECT *
   FROM Employees
   ORDER BY [Salary] DESC,[FirstName],[LastName] DESC,[MiddleName]

--Problem 16
CREATE VIEW V_EmployeesSalaries
AS
SELECT
  [FirstName],[LastName],[Salary]
FROM
    Employees

--Problem 17
CREATE VIEW V_EmployeeNameJobTitle
AS
 SELECT CONCAT([FirstName],' ',[MiddleName], ' ',[LastName])
  AS  [Full Name],[JobTitle]
  FROM Employees

-- Problem 18
SELECT  DISTINCT [JobTitle]
FROM Employees

-- Problem 19
SELECT TOP(10) *
FROM Projects
ORDER BY [StartDate],[Name]

-- Problem 20
SELECT TOP(7) [FirstName], [LastName], [HireDate]
FROM Employees
ORDER BY [HireDate] DESC

-- Problem 21
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentId IN (1, 2, 4, 11)
SELECT Salary FROM Employees
UPDATE Employees
SET Salary = Salary * 0.88
WHERE DepartmentId IN (1, 2, 4, 11)