-- Create a new stored procedure called 'Posts_GetById' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'Posts_GetById'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.Posts_GetById
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.Posts_GetById
    @PostId INT
AS
SELECT P.PostId, PostTitle, P.UserId, P.Details, P.CreateDate, P.LastUpdateDate, COUNT(C.CommentId) OVER(PARTITION BY P.PostId) AS 'TotalComments'
FROM Posts P
LEFT JOIN Comments C ON C.PostId = P.PostId
WHERE P.PostId = @PostId
GO


