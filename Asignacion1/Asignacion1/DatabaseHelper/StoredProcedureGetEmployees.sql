USE AdventureWorks2025;
GO

CREATE OR ALTER PROCEDURE dbo.uspGetEmployees
(
    @Name NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @JobTitle NVARCHAR(100) = NULL,
    @Shift NVARCHAR(100) = NULL,
    @OnlyActive BIT = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.BusinessEntityID,
        CONCAT( p.FirstName, ' ', ISNULL(p.MiddleName + ' ', ''), p.LastName) AS FullName,
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
    WHERE
        (
            @Name IS NULL
            OR @Name = ''
            OR CONCAT(p.FirstName, ' ', ISNULL(p.MiddleName + ' ', ''), p.LastName) LIKE '%' + @Name + '%'
        )
        AND
        (
            @Department IS NULL
            OR @Department = ''
            OR d.Name LIKE '%' + @Department + '%'
        )
        AND
        (
            @JobTitle IS NULL
            OR @JobTitle = ''
            OR e.JobTitle LIKE '%' + @JobTitle + '%'
        )
        AND
        (
            @Shift IS NULL
            OR @Shift = ''
            OR s.Name LIKE '%' + @Shift + '%'
        )
        AND
        (
            @OnlyActive = 0
            OR edh.EndDate IS NULL
        )
    ORDER BY FullName;
END
GO