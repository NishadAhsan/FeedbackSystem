-- Create a new stored procedure called 'Comments_Add' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'Comments_Add'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.Comments_Add
GO
CREATE PROCEDURE dbo.Comments_Add
    @CommentTitle NVARCHAR(255),
    @PostId INT,
    @UserId INT,
    @Details NVARCHAR(4000)
AS
INSERT INTO [dbo].[Comments]
    (
    CommentTitle, PostId, UserId, Details, CreateDate, LastUpdateDate
    )
VALUES
    (
        @CommentTitle, @PostId, @UserId, @Details, GetUTCDate(), NULL
    )
    GO
GO