using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppDAL.DAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class WorkoutPlanDAL: IWorkoutPlanContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";
        CommentDAL commentDAL = new CommentDAL();
        ExerciseDAL exerciseDAL = new ExerciseDAL();

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetWorkoutPlansByUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", username));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new WorkoutPlan
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            CreatorName = (string)reader["Nickname"],
                            CategoryName = (string)reader["CategoryName"],
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

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetTopWorkoutPlans", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new WorkoutPlan
                        {
                            Id = (int) reader["ID"],
                            Name = (string) reader["Name"],
                            CreatorName = (string) reader["Nickname"],
                            CategoryName = (string) reader["CategoryName"],
                            Kudos = (int) reader["Kudos"]
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

        public WorkoutPlan GetWorkoutPlan(string nickname, string planname)
        {
            WorkoutPlan result = new WorkoutPlan();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetWorkoutPlanInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Planname", planname));
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = (int) reader["ID"];
                        result.Name = (string) reader["Name"];
                        result.CreatorName = (string) reader["Nickname"];
                        result.CategoryName = (string) reader["CategoryName"];
                        result.Kudos = (int) reader["Kudos"];
                    }

                    reader.Close();
                    conn.Close();
                }

                result.Exercises = exerciseDAL.GetWorkoutPlanExercises(result.Name, result.CreatorName);
                result.Comments = commentDAL.GetCommentsByWorkoutplan(result.Id);
            }
            catch(Exception)
            {
            }
            return result;
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            WorkoutPlan result = new WorkoutPlan();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetWorkoutPlanById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = (int)reader["ID"];
                        result.Name = (string)reader["Name"];
                        result.CreatorName = (string)reader["Nickname"];
                        result.CategoryName = (string)reader["CategoryName"];
                        result.Kudos = (int)reader["Kudos"];
                    }
                    reader.Close();
                    conn.Close();
                }
                result.Exercises = exerciseDAL.GetWorkoutPlanExercises(result.Name, result.CreatorName);
                result.Comments = commentDAL.GetCommentsByWorkoutplan(result.Id);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddWorkoutPlan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", workoutPlanToAdd.Name));
                    cmd.Parameters.Add(new SqlParameter("@Username", workoutPlanToAdd.CreatorName));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", workoutPlanToAdd.CategoryName));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public void RemoveWorkout(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RemoveWorkoutPlan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public List<WorkoutPlan> SearchWorkoutsByName(string name)
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SearchWorkoutsByName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", name));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new WorkoutPlan
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            CreatorName = (string)reader["Nickname"],
                            CategoryName = (string)reader["CategoryName"],
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

        public void AddExerciseToWorkout(int workoutPlanId, int exerciseId, int repCount, int setCount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddExerciseToWorkout", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SetTarget", setCount));
                    cmd.Parameters.Add(new SqlParameter("@RepTarget", repCount));
                    cmd.Parameters.Add(new SqlParameter("@WorkoutPlanId", workoutPlanId));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseID", exerciseId));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        public string AddKudoToWorkoutPlan(int workoutplanId, string nickname)
        {
            string result = "Unable to add kudo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddKudoToWorkoutplan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));
                    cmd.Parameters.Add(new SqlParameter("@WorkoutplanID", workoutplanId));
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
    }
}
