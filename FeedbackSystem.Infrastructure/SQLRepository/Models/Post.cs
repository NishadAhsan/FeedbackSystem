using System;

namespace FeedbackSystem.Infrastructure.SQLRepository.Models
{
  public class Post: Loggable
  {
    public int PostId { get; set; }
    public string PostTitle { get; set; }
    public int UserId { get; set; }
    public string Details { get; set; }
  }
}
