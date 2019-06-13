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
            //todo add view first then add in Database
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
    }
}
