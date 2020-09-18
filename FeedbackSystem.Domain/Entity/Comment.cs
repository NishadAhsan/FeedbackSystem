using FeedbackSystem.Domain.ValueObjects;

namespace FeedbackSystem.Domain.Entity
{
  public class Comment
  {
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string CommentTitle { get; set; }
    public string Details { get; set; }
    public int UserId { get; set; }
    public InterestCount InterestCount { get; set; }
  }
}
