namespace FeedbackSystem.Domain.Entity
{
  public class CommentInterest
  {
    public int CommentInterestId { get; set; }
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public bool Interest { get; set; }
  }
}
