-- Create a new stored procedure called 'CommonInterest_ToggleInterest' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'CommonInterest_ToggleInterest'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.CommonInterest_ToggleInterest
GO
CREATE PROCEDURE dbo.CommonInterest_ToggleInterest
    @CommentId INT,
    @Interest BIT,
    @UserId INT
AS
UPDATE CommentInterests SET Interest = @Interest, LastUpdateDate = GETUTCDATE() WHERE CommentId = @CommentId AND UserId = @UserId
GO