-- Create a new stored procedure called 'CommentInterests_Add' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'CommentInterests_Add'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.CommentInterests_Add
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.CommentInterests_Add
    @CommentId INT, @UserId INT, @Interest BIT
AS
    INSERT INTO CommentInterests VALUES(
        @CommentId, @UserId, @Interest, GETUTCDATE(), NULL
    )
GO