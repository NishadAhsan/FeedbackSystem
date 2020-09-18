using FeedbackSystem.Application.Services.Comments;
using FeedbackSystem.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommentsController : ControllerBase
  {
    private readonly ICommentsService _service;
    public CommentsController(ICommentsService commentsService)
    {
      this._service = commentsService;
    }

    [HttpGet("read")]
    public IActionResult ReadAllComments()
    {
      var comments = _service.GetAll();
      return Ok(comments);
    }

    [HttpGet("read/post/{postId:int:min(1)}")]
    public IActionResult ReadAllCommentsByPostId(int postId)
    {
      var comments = _service.GetAll(postId);
      return Ok(comments);
    }

    [HttpGet("read/{commentId:int:min(1)}")]
    public IActionResult ReadPost(int commentId)
    {
      var comment = _service.Get(commentId);
      return Ok(comment);
    }

    [HttpPost("write")]
    public IActionResult WritePost([FromBody] Comment comment)
    {
      // check validity
      _service.Save(comment);
      return Ok();
    }

    [HttpPost("interest/add")]
    public IActionResult AddInterest([FromBody] CommentInterest commentInterest)
    {
      _service.AddInterest(commentInterest);
      return Ok();
    }
  }
}
