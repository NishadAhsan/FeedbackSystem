using FeedbackSystem.Domain.Entity;
using System.Collections.Generic;

namespace FeedbackSystem.Application.Services.Comments
{
  public interface ICommentsService
  {
    void Save(Comment post);
    Comment Get(int commentId);
    IEnumerable<Comment> GetAll();
    IEnumerable<Comment> GetAll(int postId);
    void AddInterest(CommentInterest commentInterest);
  }
}
