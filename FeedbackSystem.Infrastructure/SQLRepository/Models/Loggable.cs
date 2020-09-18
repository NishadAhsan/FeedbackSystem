using System;

namespace FeedbackSystem.Infrastructure.SQLRepository.Models
{
  public class Loggable
  {
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
  }
}
