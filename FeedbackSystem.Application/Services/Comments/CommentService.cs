using FeedbackSystem.Application.Repositories;
using FeedbackSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackSystem.Application.Services.Comments
{
  public class CommentService : ICommentsService
  {
    private readonly ICommentsRepo _repo;
    private readonly ICommentInterestsRepo _interestRepo;
    public CommentService(ICommentsRepo commentsRepo, ICommentInterestsRepo commentInterestsRepo)
    {
      this._repo = commentsRepo;
      this._interestRepo = commentInterestsRepo;
    }

    public void AddInterest(CommentInterest commentInterest)
    {
      _interestRepo.Add(commentInterest);
    }

    public Comment Get(int commentId)
    {
      Comment comment = _repo.Get(commentId);
      if (comment != null)
        comment.InterestCount = _repo.GetInterestCount(commentId);
      return comment;
    }

    public IEnumerable<Comment> GetAll()
    {
      return _repo.GetAll();
    }

    public void Save(Comment comment)
    {
      _repo.Add(comment);
    }
  }
}
