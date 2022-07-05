-- Problem 01
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)


CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(10,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

-- Problem 02
INSERT INTO Files([Name],Size,ParentId,CommitId)
     VALUES      ('Trade.idk',2598.0,1,1),
	             ('menu.net',9238.31,2,2),
				 ('Administrate.soshy',1246.93,3,3),
				 ('Controller.php',7353.15,4,4),
				 ('Find.java',9957.86,5,5),
				 ('Controller.json',14034.87,3,6),
				  ('Operate.xix',7662.92,7,7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId)
     VALUES      ('Critical Problem with HomeController.cs file','open',1,4),
	             ('Typo fix in Judge.html','open',4,3),
				 ('Implement documentation for UsersService.cs','closed',8,2),
				 ('Unreachable code in Index.cs','open',9,8)
				
-- Problem 03

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6


-- Problem 04

DELETE Issues
WHERE RepositoryId = 3

DELETE RepositoriesContributors
WHERE [RepositoryId] = 3

--Problem 05

SELECT [Id],[Message],[RepositoryId],[ContributorId]
FROM Commits
ORDER BY [Id],[Message],[RepositoryId],[ContributorId]

--Problem 06
SELECT [Id],[Name],[Size]
FROM Files
WHERE Size >1000 AND [Name] LIKE '%html%'
ORDER BY [Size] DESC,Id,[Name]

--Problem 07
SELECT i.Id,
CONCAT(u.Username,+' : ',i.Title) IssueAssignee
FROM Issues AS i
JOIN [Users] AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

-- Problem 08

SELECT  fp.Id,fp.[Name],
CONCAT(fp.Size,'KB') Size
FROM  Files AS fch
 full outer JOIN Files as fp ON fch.ParentId = fp.Id
WHERE fch.Id IS NULL
ORDER BY fp.Id,fp.[Name],fp.Size DESC 

--Problem 11

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
        DECLARE @userId INT = (
		SELECT Id
		FROM Users
		WHERE Username = @username
		)

		DECLARE @userCount INT = (
		SELECT COUNT(Id)
		FROM Commits
		WHERE [ContributorId] = @userId
		
		)
   
    RETURN @userCount
END;

--Problem 12

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100) ) 
AS
BEGIN
      SELECT [Id],f.[Name],
	  CONCAT (f.Size,'KB')
	  FROM Files
	  AS f
	  WHERE [Name] LIKE CONCAT('%[.]',@fileExtension)
   ORDER BY Id,[Name],f.Size DESC
    
END;

EXEC usp_SearchForFiles 'txt'
