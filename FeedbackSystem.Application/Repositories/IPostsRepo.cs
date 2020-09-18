using FeedbackSystem.Domain.Entity;
using System.Collections.Generic;

namespace FeedbackSystem.Application.Repositories
{
  public interface IPostsRepo
  {
    void Add(Post post);
    List<Post> GetAll();
    Post Get(int postId);
  }
}
