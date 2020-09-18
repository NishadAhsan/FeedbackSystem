namespace FeedbackSystem.Domain.Entity
{
  public class Post
  {
    public int PostId { get; set; }
    public string PostTitle { get; set; }
    public int UserId { get; set; }
    public string Details { get; set; }
    public int TotalComments { get; set; }
  }
}
