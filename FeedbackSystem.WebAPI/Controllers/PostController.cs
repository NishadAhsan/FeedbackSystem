using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackSystem.Application.Services.Posts;
using FeedbackSystem.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : ControllerBase
  {
    private readonly IPostService _service;
    public PostController(IPostService postService)
    {
      this._service = postService;
    }

    [HttpGet("read")]
    public IActionResult ReadAllPost()
    {
      var posts = _service.GetAll();
      return Ok(posts);
    }

    [HttpGet("read/{postId:int:min(1)}")]
    public IActionResult ReadPost(int postId)
    {
      var post = _service.Get(postId);
      return Ok(post);
    }

    [HttpPost("write")]
    public IActionResult WritePost([FromBody] Post post)
    {
      // check validity
      _service.Save(post);
      return Ok();
    }
  }
}
