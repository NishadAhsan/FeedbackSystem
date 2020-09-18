-- Create a new stored procedure called 'Posts_Add' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'Posts_Add'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.Posts_Add
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.Posts_Add
    @PostTitle NVARCHAR(255),
    @Details NVARCHAR(4000),
    @UserId INT
AS
    INSERT INTO Posts VALUES(
        @PostTitle, @UserId, @Details, GETUTCDATE(), NULL
    )
GO