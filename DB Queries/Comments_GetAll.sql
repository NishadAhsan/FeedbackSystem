-- Create a new stored procedure called 'Comments_GetAll' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'Comments_GetAll'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.Comments_GetAll
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.Comments_GetAll
AS
SELECT C.CommentId, CommentTitle, Details, C.LastUpdateDate, C.CreateDate, C.PostId, C.UserId,
        COUNT(CASE CI.Interest WHEN 1 THEN 1 ELSE NULL END) OVER(PARTITION BY C.CommentId) AS 'InterestedCount',
        COUNT(CASE CI.Interest WHEN 0 THEN 1 ELSE NULL END) OVER(PARTITION BY C.CommentId) AS 'NotInterestedCount'
FROM Comments C
LEFT JOIN CommentInterests CI ON CI.CommentId =C.CommentId
GO