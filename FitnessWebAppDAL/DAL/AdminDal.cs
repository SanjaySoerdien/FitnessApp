using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class AdminDal : IAdminContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";

        public void AddCategory(string category)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category", category));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ChangeCategory(string categoryNew, string categoryOld)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateCategoryAddCommentToExercise", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CategoryOld", categoryOld));
                cmd.Parameters.Add(new SqlParameter("@CategoryNew", categoryNew));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteCategory(string category)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category", category));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddExercise", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", exercise.Name));
                cmd.Parameters.Add(new SqlParameter("@Category", exercise.MuscleGroup));
                cmd.Parameters.Add(new SqlParameter("@Description", exercise.Description));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteExercise(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RemoveExercise", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Change> GetRecentChanges()
        {
            List<Change> result = new List<Change>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetRecentChanges", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Change
                    {
                        username = (string)reader["Username"],
                        changeText = (string)reader["ChangeText"],
                        time = (DateTime)reader["Date"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result; 
        }

        public List<Change> GetMoreChanges()
        {
            List<Change> result = new List<Change>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetMoreChanges", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Change
                    {
                        username = (string)reader["Username"],
                        changeText = (string)reader["ChangeText"],
                        time = (DateTime)reader["Date"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
    }
}
