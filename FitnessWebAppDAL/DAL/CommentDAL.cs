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

            try
            {
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
                            Text = (string)reader["Text"],
                            Kudos = (int)reader["Kudos"],
                            Nickname = (string)reader["Nickname"]
                        });
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch(Exception)
            {
            }
            return result;
        }

        public List<Comment> GetCommentsByWorkoutplan(int id)
        {
            List<Comment> result = new List<Comment>();
            try
            {
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
                            Kudos = (int)reader["Kudos"],
                            Nickname = (string)reader["Nickname"]
                        });
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        public void AddCommentToWorkout(Comment commentToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddCommentToWorkoutplan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Username", commentToAdd.Nickname));
                    cmd.Parameters.Add(new SqlParameter("@Text", commentToAdd.Text));
                    cmd.Parameters.Add(new SqlParameter("@WorkoutplanID", commentToAdd.ForeignID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddCommentToExercise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Username", commentToAdd.Nickname));
                    cmd.Parameters.Add(new SqlParameter("@Text", commentToAdd.Text));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseID", commentToAdd.ForeignID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public string AddKudoToComment(int commentId,string nickname)
        {
            string result = "Unable to add kudo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddKudoToComment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));
                    cmd.Parameters.Add(new SqlParameter("@CommentID", commentId));
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = "Kudo added!";
                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // <-- but this will
                {
                    return "Already added a kudo!";
                }
            }
            return result;
        }

        public void RemoveComment(int commentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RemoveComment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", commentId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
