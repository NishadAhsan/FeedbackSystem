using FeedbackSystem.Domain.Entity;

namespace FeedbackSystem.Application.Repositories
{
  public interface ICommentInterestsRepo
  {
    void Add(CommentInterest commentInterest);
    void Toggle(CommentInterest commentInterest);
  }
}
