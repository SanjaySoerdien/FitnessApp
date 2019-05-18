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
                SqlCommand cmd = new SqlCommand("Login", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new WorkoutPlan
                    {
                       Name = (string)reader["Name"],
                       CreatorName = (string)reader["Nickname"],
                       CategoryName = (string)reader["CategoryName"],
                       Kudos = (int)reader["Kudo"]
                    });
                    reader.Close();
                    conn.Close();
                }
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

        public List<Excercise> GetWorkoutPlanExcercises(string username, string planname)
        {
            List<Excercise> result = new List<Excercise>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT * from dbo.Workoutplan " +
                                                    $"WHERE Name = '{planname}' AND UserID = {username}", conn); //todo innerjoins enzo , maak de query af
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Excercise
                    {
                        Name = (string) reader["Name"],
                        SetTarget = (int) reader["SetTarget"],
                        RepTarget = (int) reader["RepsTarget"],
                        MuscleGroup = (string) reader["Category"]
                    });
                    reader.Close();
                    conn.Close();
                }
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
