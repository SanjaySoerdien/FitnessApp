using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL.DAL
{
    class ExerciseDAL : IExerciseContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";

        public Exercise GetExercise(string name)
        {
            Exercise result = new Exercise();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetExerciseByName", conn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", name));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Exercise
                    {
                        Id = (int) reader["Id"], //TODO check deze shit
                        MuscleGroup = (string) reader["Category"],
                        Name = (string) reader["Name"],
                    };
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public Exercise GetExercise(int id)
        {
            Exercise result = new Exercise();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetExcerciseByID", conn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Exercise
                    {
                        Id = (int)reader["Id"], 
                        MuscleGroup = (string)reader["Category"],
                        Name = (string)reader["Name"]
                    };
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public List<Exercise> GetTopExercises()
        {
            List<Exercise> result = new List<Exercise>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetTopExercises", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Exercise
                    {
                        Id = (int)reader["Id"],
                        MuscleGroup = (string)reader["Category"],
                        Name = (string)reader["Name"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public List<string> GetAllCategories()
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["Category"]);
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
       
        public List<Exercise> GetExercisesByCategory(string category)
        {
            List<Exercise> result = new List<Exercise>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetExercisesByCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category", category));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Exercise
                    {
                        Id = (int)reader["Id"], 
                        MuscleGroup = (string)reader["Category"],
                        Name = (string)reader["Name"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
        
        public void AddExercise()
        {
            throw new NotImplementedException();
        }
    }
}
