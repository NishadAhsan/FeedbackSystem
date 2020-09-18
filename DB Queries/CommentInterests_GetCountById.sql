SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[CommentInterests_GetCountById]
    @CommentId INT
AS
SELECT COUNT(CI.CommentId) AS 'Interested', COUNT(CI.CommentId) AS 'NotInterested'
FROM CommentInterests CI
WHERE CommentId = @CommentId
GROUP BY CI.Interest
GO
