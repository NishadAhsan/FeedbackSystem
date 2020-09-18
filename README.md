# FeedbackSystem

## Initialization

1. Run the DB Queries.
2. Change connection string in the FeedbackSystem.Infrastructure.SQLRepository.Repositories files.

#### Design Pattern
I have used Port and Adapters(Haxagonal) pattern, also attempted to use SOLID principles. This is not a complete implementation of the pattern but a starting point where a lot of things need to be done.

#### API Endpoints
- Post: Add new post http://localhost:2500/api/post/write
    {
    "PostTitle": "I am using SQL",
    "UserId": 1,
    "Details": "I am so slow!!!!"
    }
- Post: Read all post http://localhost:2500/api/post/read
- Post: Read one post http://localhost:2500/api/post/read/:postId
- Comment: Add new comment http://localhost:2500/api/comments/write
        {
        "PostId": 1,
        "CommentTitle": "My Comment",
        "Details": "This is my first comment",
        "UserId": 1
        }
- Comment: Read all comment http://localhost:2500/api/comments/read
- Comment: Read one comment http://localhost:2500/api/comments/read/:commentId
- Comment: Like/Dislike comment http://localhost:2500/api/comments/interest/add
        {
        "CommentId": 1,
        "UserId": 3,
        "Interest": false
        }
- Comment: Read all comments of a post http://localhost:2500/api/comments/read/post/:postId
    
#### Things to improve
This is a list of things that I did here in a bad bad way that need to be improved.

- Setup proper appSettings and module system to include ConnectionStrings and other needed stuff to the needed class library.
- Need to decouple Domain models from Database models.
- Add validation to API requests, preferably using FluentValidationAPI.
- Need to handle exceptions, Global custom exception with logging feature.
- Need to add pagination.


> I am new to entity framework, that's why I went for ADO.NET, which obviously took more time.
