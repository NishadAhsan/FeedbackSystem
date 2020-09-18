using FeedbackSystem.Domain.Entity;
using System.Collections.Generic;

namespace FeedbackSystem.Application.Services.Posts
{
  public interface IPostService
  {
    void Save(Post post);
    Post Get(int postId);
    IEnumerable<Post> GetAll();
  }
}
