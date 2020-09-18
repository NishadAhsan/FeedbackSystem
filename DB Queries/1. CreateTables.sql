CREATE DATABASE FeedbackDB;

-- Create Posts table
CREATE TABLE Posts(
    PostId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PostTitle NVARCHAR(255) NULL,
    UserId INT NOT NULL,
    Details NVARCHAR(4000) NULL,
    CreateDate DATETIME NOT NULL,
    LastUpdateDate DATETIME NULL
);

-- Create Comments table
CREATE TABLE Comments(
    CommentId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CommentTitle NVARCHAR(255) NULL,
    PostId INT NOT NULL,
    UserId INT NOT NULL,
    Details NVARCHAR(4000) NULL,
    CreateDate DATETIME NOT NULL,
    LastUpdateDate DATETIME NULL,
    FOREIGN KEY (PostId) REFERENCES Posts(PostId)
);

-- Create CommentInterests table
CREATE TABLE CommentInterests(
    InterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CommentId INT NOT NULL,
    UserId INT NOT NULL,
    Interest BIT NOT NULL,
    CreateDate DATETIME NOT NULL,
    LastUpdateDate DATETIME NULL,
    FOREIGN KEY (CommentId) REFERENCES Comments(CommentId)
)