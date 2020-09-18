using FeedbackSystem.Application.Repositories;
using FeedbackSystem.Domain.Entity;
using System.Collections.Generic;

namespace FeedbackSystem.Application.Services.Posts
{
  public class PostService : IPostService
  {
    private readonly IPostsRepo _repo;
    public PostService(IPostsRepo postsRepo)
    {
      this._repo = postsRepo;
    }

    public Post Get(int postId)
    {
      return _repo.Get(postId);
    }

    public IEnumerable<Post> GetAll()
    {
      return _repo.GetAll();
    }

    public void Save(Post post)
    {
      _repo.Add(post);
    }
  }
}
