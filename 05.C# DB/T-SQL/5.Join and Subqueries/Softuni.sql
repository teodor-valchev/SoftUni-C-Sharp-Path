--Problem 01
SELECT TOP (5) [e].[EmployeeID],[e].[JobTitle],[a].[AddressID],[a].[AddressText] 
      FROM [Employees] AS [e]
INNER JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID] 
  ORDER BY [a].[AddressID]

--Problem 02
SELECT TOP(50) [e].[FirstName],[e].[LastName],[t].[Name],[a].[AddressText] 
      FROM [Employees] AS [e]
      JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
      JOIN [Towns] AS [t] ON [t].[TownID] = [a].[TownID]
  ORDER BY [e].[FirstName],[e].[LastName]

--Problem 03
 SELECT [e].[EmployeeID],[e].[FirstName],[e].[LastName],[d].[Name] 
  FROM [Employees] AS [e]
  JOIN [Departments] AS [d] ON [e].DepartmentID = [d].[DepartmentID]
 WHERE [d].[Name] = 'Sales'
 ORDER BY [e].[EmployeeID]

--Problem 04
 SELECT TOP (5) [e].[EmployeeID],[e].[FirstName],[e].[Salary],[d].[Name] 
       FROM [Employees] AS [e]
       JOIN [Departments] AS [d] ON [e].DepartmentID = [d].[DepartmentID]
      WHERE [e].[Salary] > 15000
   ORDER BY [d].[DepartmentID]

--Problem 05
SELECT TOP(3) [e].[EmployeeID], [e].[FirstName]
      FROM [Employees] AS [e]
     WHERE [e].[EmployeeID] NOT IN (SELECT [EmployeeID] FROM [EmployeesProjects])
  ORDER BY [e].[EmployeeID]

 --Problem 06
    SELECT  [e].[FirstName], [e].[LastName],[e].[HireDate],[d].[Name] AS [DeptName]
      FROM [Employees] AS [e]
      JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
	 WHERE [e].[HireDate] > '1999-01-01' AND ([d].[Name] = 'Sales' OR [d].[Name] = 'Finance')
  ORDER BY [e].[HireDate]

 -- Problem 07
    SELECT TOP(5)  [e].[EmployeeID],[e].[FirstName],[p].[Name]
      FROM [Employees] AS [e]
      JOIN [EmployeesProjects] [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
      JOIN [Projects] [p] ON [ep].[ProjectID] = [p].[ProjectID]
	  WHERE [p].[StartDate] > '2002-08-13'
	  ORDER BY [e].[EmployeeID]

 -- Problem 08

SELECT [e].[EmployeeID], [e].[FirstName], 
	(CASE
		WHEN  DATEPART(YEAR, [p].[StartDate]) >= 2005 THEN NULL
		ELSE [p].[Name]
	END) AS [ProjectName]
FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
LEFT JOIN [Projects] [p] ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [e].[EmployeeID] = 24 

-- Problem 09
SELECT [e].[EmployeeID],[e].[FirstName],[e].[ManagerID],[em].[FirstName] AS [ManagerName]
FROM Employees as [e]
JOIN [Employees] [em] ON [e].[ManagerID] = [em].[EmployeeID]
WHERE [e].[ManagerID] IN (3,7)
ORDER BY [e].[EmployeeID]

-- Problem 10
SELECT TOP (50) [e].[EmployeeID],
   CONCAT([e].[FirstName] +' '+ [e].[LastName],' ') AS [EmployeeName],
   CONCAT([em].[FirstName] +' '+ [em].[LastName],' ') AS [ManagerName],
   CONCAT(d.Name,'') AS [DepartmentName]
   FROM Employees as [e]
   JOIN [Employees] [em] ON [e].[ManagerID] = [em].[EmployeeID]
   JOIN [Departments] [d]ON [d].[DepartmentID] = [e].[DepartmentID]
   ORDER BY [e].[EmployeeID]

--Problem 11
SELECT TOP(1) AVG([Salary]) AS [MinAverageSalary]
        FROM [Employees]
    GROUP BY [DepartmentID]
    ORDER BY [MinAverageSalary]
