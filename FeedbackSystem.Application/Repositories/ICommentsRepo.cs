using FeedbackSystem.Domain.Entity;
using FeedbackSystem.Domain.ValueObjects;
using System.Collections.Generic;

namespace FeedbackSystem.Application.Repositories
{
  public interface ICommentsRepo
  {
    void Add(Comment comment);
    Comment Get(int commentId);
    List<Comment> GetAll();
    InterestCount GetInterestCount(int commentId);
  }
}
