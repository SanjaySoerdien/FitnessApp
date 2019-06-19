using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class ExerciseDAL : IExerciseContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";
        CommentDAL commentDAL = new CommentDAL();

        public Exercise GetExercise(string name)
        {
            Exercise result = new Exercise();
            try
            {
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
                            Id = (int)reader["Id"],
                            MuscleGroup = (string)reader["Category"],
                            Name = (string)reader["Name"],
                        };
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

        public Exercise GetExercise(int id)
        {
            Exercise result = new Exercise();
            try
            {
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
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Kudos = (int)reader["Kudos"]
                        };
                    }
                    result.Comments = commentDAL.GetCommentsByExercise(result.Id);
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        public List<Exercise> GetTopExercises()
        {
            List<Exercise> result = new List<Exercise>();
            try
            {
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
                            Name = (string)reader["Name"],
                            Kudos = (int)reader["Kudos"]
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

        public List<string> GetAllCategories()
        {
            List<string> result = new List<string>();
            try
            {
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
            }
            catch (Exception)
            {
            }
            return result;
        }
       
        public List<Exercise> GetExercisesByCategory(string category)
        {
            List<Exercise> result = new List<Exercise>();
            try
            {
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
                            Name = (string)reader["Name"],
                            Kudos = (int)reader["Kudos"]
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

        public List<Exercise> GetWorkoutPlanExercises(string planname, string nickname)
        {
            List<Exercise> result = new List<Exercise>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetWorkoutPlanExercises", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Planname", planname));
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Exercise
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            SetTarget = (int)reader["SetsTarget"],
                            RepTarget = (int)reader["RepsTarget"],
                            MuscleGroup = (string)reader["Category"]
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

        public ErrorMessage AddKudoToExercise(int exerciseId, string nickname)
        {
            ErrorMessage result = ErrorMessage.Unsuccesfull;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddKudoToExercise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));
                    cmd.Parameters.Add(new SqlParameter("@exerciseID", exerciseId));
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = ErrorMessage.Succes;
                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Detects duplicate key error
                {
                    return ErrorMessage.Duplicate;
                }
            }
            return result;
        }
    }
}
