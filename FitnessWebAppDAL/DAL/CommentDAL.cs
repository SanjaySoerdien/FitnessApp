using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class CommentDAL : ICommentContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";

        public List<Comment> GetCommentsByExercise(int id)
        {
            List<Comment> result = new List<Comment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCommmentsByExercise", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Comment
                    {
                        ID = (int)reader["Id"],
                        Text = (string) reader["Text"],
                        //Kudos = (int)reader["Kudos"], todo fix kudos hier
                        Nickname = (string)reader["Nickname"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public List<Comment> GetCommentsByWorkoutplan(int id)
        {
            List<Comment> result = new List<Comment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCommmentsByWorkoutplan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Comment
                    {
                        ID = (int)reader["Id"],
                        Text = (string)reader["Text"],
                        //Kudos = (int)reader["Kudos"], TODO fix later, kudo stuff edit DB eerst
                        Nickname = (string)reader["Nickname"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
    }
}
