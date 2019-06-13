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

        public int AddCategory(string category)
        {
            int result = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Category", category));
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int ChangeCategory(string categoryNew, string categoryOld)
        {
            int result = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryOld", categoryOld));
                    cmd.Parameters.Add(new SqlParameter("@CategoryNew", categoryNew));
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        
        }

        public int DeleteCategory(string category)
        {
            int result = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteCategory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Category", category));
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
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
                        changeText = (string)reader["ChangesText"],
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
                        changeText = (string)reader["ChangesText"],
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
