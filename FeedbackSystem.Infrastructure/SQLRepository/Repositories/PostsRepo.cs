using FeedbackSystem.Domain.Entity;
using FeedbackSystem.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FeedbackSystem.Infrastructure.SQLRepository.Repositories
{
  public class PostsRepo : IPostsRepo
  {
    private readonly string _connectionString;
    public PostsRepo()
    {
      this._connectionString = "Data Source=DESKTOP-9JQOQ43\\SQLExpress;Initial Catalog=FeedbackDB; User Id=sa; Password=nishad0963;";
    }

    public void Add(Post post)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Posts_Add", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
          cmd.Parameters.AddWithValue("@Details", post.Details);
          cmd.Parameters.AddWithValue("@UserId", post.UserId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    public Post Get(int postId)
    {
      Post post = null;
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Posts_GetById", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@PostId", postId);

          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              post = new Post
              {
                PostId = Convert.ToInt32(reader["PostId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Details = reader["Details"].ToString(),
                PostTitle = reader["PostTitle"].ToString(),
                TotalComments = Convert.ToInt32(reader["TotalComments"])
              };
            }
          }
        }
      }
      return post;
    }

    public List<Post> GetAll()
    {
      List<Post> posts = new List<Post>();
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        using (SqlCommand cmd = new SqlCommand("Posts_GetAll", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              Post post = new Post
              {
                PostId = Convert.ToInt32(reader["PostId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Details = reader["Details"].ToString(),
                PostTitle = reader["PostTitle"].ToString(),
                TotalComments = Convert.ToInt32(reader["TotalComments"])
              };
              posts.Add(post);
            }
          }
        }
      }
      return posts;
    }
  }
}
