namespace FeedbackSystem.Infrastructure.SQLRepository.Models
{
  public class CommentInterest : Loggable
  {
    public int CommentInterestId { get; set; }
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public bool Interest { get; set; }
  }
}
