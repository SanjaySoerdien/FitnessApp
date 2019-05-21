using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class WorkoutPlanDAL: IWorkoutPlanContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
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
                       Kudos = (int)reader["Kudo"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
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
                        Id = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        CreatorName = (string)reader["Nickname"],
                        CategoryName = (string)reader["CategoryName"],
                        Kudos = (int)reader["Kudo"]
                    });
                }
                reader.Close();
                conn.Close();
            }

            return result;
        }

        public List<Exercise> GetWorkoutPlanExercises(string nickname, string planname)
        {
            List<Exercise> result = new List<Exercise>();
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
                        Name = (string) reader["Name"],
                        SetTarget = (int) reader["SetsTarget"],
                        RepTarget = (int) reader["RepsTarget"],
                        MuscleGroup = (string) reader["Category"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            throw new NotImplementedException();
            //TODO Make dis
        }

    }
}
