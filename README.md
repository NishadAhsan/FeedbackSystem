# FeedbackSystem

## Initialization

1. Run the DB Queries.
2. Change connection string in the FeedbackSystem.Infrastructure.SQLRepository.Repositories files.

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
    
#### Things to improve
This is a list of things that I did here in a bad bad way that need to be improved.

- Setup proper appSettings and module system to include ConnectionStrings and other needed stuff to the needed class library.
- Need to decouple Domain models from Database models.
- Add validation to API requests, preferably using FluentValidationAPI.
- Need to handle exceptions, Global custom exception with logging feature.


> I am new to entity framework, that's why I went for ADO.NET, which obviously took more time.
