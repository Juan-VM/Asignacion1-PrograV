USE AdventureWorks2025;
GO

CREATE OR ALTER PROCEDURE dbo.uspGetEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.BusinessEntityID,

        CONCAT(
            p.FirstName,
            ' ',
            ISNULL(p.MiddleName + ' ', ''),
            p.LastName
        ) AS FullName,

        e.JobTitle,

        d.Name AS Department,

        s.Name AS ShiftName,

        CASE
            WHEN edh.EndDate IS NULL THEN 1
            ELSE 0
        END AS ActiveEmployee

    FROM HumanResources.Employee e

        INNER JOIN Person.Person p
            ON e.BusinessEntityID = p.BusinessEntityID

        INNER JOIN HumanResources.EmployeeDepartmentHistory edh
            ON e.BusinessEntityID = edh.BusinessEntityID

        INNER JOIN HumanResources.Department d
            ON edh.DepartmentID = d.DepartmentID

        INNER JOIN HumanResources.Shift s
            ON edh.ShiftID = s.ShiftID

    ORDER BY FullName;
END
GO