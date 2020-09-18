namespace FeedbackSystem.Infrastructure.SQLRepository.Models
{
  public class Comment: Loggable
  {
    public int CommentId { get; set; }
    public string CommentTitle { get; set; }
    public string Details { get; set; }
    public int UserId { get; set; }
  }
}
