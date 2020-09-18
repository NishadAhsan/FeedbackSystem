using FeedbackSystem.Application.Repositories;
using FeedbackSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FeedbackSystem.Infrastructure.SQLRepository.Repositories
{
  public class CommentInterestsRepo : ICommentInterestsRepo
  {
    private readonly string _connectionString;
    public CommentInterestsRepo()
    {
      this._connectionString = "Data Source=DESKTOP-9JQOQ43\\SQLExpress;Initial Catalog=FeedbackDB; User Id=sa; Password=nishad0963;";
    }
    public void Add(CommentInterest commentInterest)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("CommentInterests_Add", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@CommentId", commentInterest.CommentId);
          cmd.Parameters.AddWithValue("@Interest", commentInterest.Interest);
          cmd.Parameters.AddWithValue("@UserId", commentInterest.UserId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    public void Toggle(CommentInterest commentInterest)
    {
      throw new NotImplementedException();
    }
  }
}
