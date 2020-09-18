using FeedbackSystem.Application.Repositories;
using FeedbackSystem.Domain.Entity;
using FeedbackSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FeedbackSystem.Infrastructure.SQLRepository.Repositories
{
  public class CommentsRepo : ICommentsRepo
  {
    private readonly string _connectionString;

    public CommentsRepo()
    {
      this._connectionString = "Data Source=DESKTOP-9JQOQ43\\SQLExpress;Initial Catalog=FeedbackDB; User Id=sa; Password=nishad0963;";
    }

    public void Add(Comment comment)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Comments_Add", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@CommentTitle", comment.CommentTitle);
          cmd.Parameters.AddWithValue("@Details", comment.Details);
          cmd.Parameters.AddWithValue("@UserId", comment.UserId);
          cmd.Parameters.AddWithValue("@PostId", comment.PostId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    public Comment Get(int commentId)
    {
      Comment comment = null;
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Comments_GetById", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@CommentId", commentId);

          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              comment = new Comment
              {
                PostId = Convert.ToInt32(reader["PostId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Details = reader["Details"].ToString(),
                CommentTitle = reader["CommentTitle"].ToString(),
                CommentId = Convert.ToInt32(reader["CommentId"])
              };
            }
          }
        }
      }
      return comment;
    }

    public List<Comment> GetAll()
    {
      List<Comment> comments = new List<Comment>();
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Comments_GetAll", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              Comment comment = new Comment
              {
                CommentId = Convert.ToInt32(reader["CommentId"]),
                CommentTitle = reader["CommentTitle"].ToString(),
                Details = reader["Details"].ToString(),
                PostId = Convert.ToInt32(reader["PostId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                InterestCount = new InterestCount
                {
                  Interested = Convert.ToInt32(reader["InterestedCount"]),
                  NotInterested = Convert.ToInt32(reader["NotInterestedCount"])
                }
              };
              comments.Add(comment);
            }
          }
        }
      }
      return comments;
    }

    public InterestCount GetInterestCount(int commentId)
    {
      InterestCount count = null;
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("CommentInterests_GetCountById", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@CommentId", commentId);

          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              count = new InterestCount
              {
                Interested = Convert.ToInt32(reader["Interested"]),
                NotInterested = Convert.ToInt32(reader["NotInterested"])
              };
            }
          }
        }
      }
      return count;
    }
  }
}
