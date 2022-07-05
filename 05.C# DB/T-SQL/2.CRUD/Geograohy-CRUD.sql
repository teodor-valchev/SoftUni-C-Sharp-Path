--Problem 22
SELECT [PeakName]
FROM Peaks
ORDER BY [PeakName]

--Problem 23
SELECT TOP(30) [CountryName], [Population]
FROM Countries
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName]

--Problem 24
SELECT [CountryName],[CountryCode],
CASE [CurrencyCode]
WHEN   'EUR' THEN 'Euro'
ELSE
'Not Euro'
END
FROM Countries
ORDER BY [CountryName]



