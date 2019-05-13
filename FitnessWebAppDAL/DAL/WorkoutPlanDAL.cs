using System;
using System.Collections.Generic;
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
                SqlCommand command = new SqlCommand($"SELECT * from dbo.Workoutplan WHERE Userid = '{username}'", conn);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new WorkoutPlan
                    {
                        Name = (string) reader["Name"],
                        Kudos = (int) reader["Kudos"],
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
                SqlCommand command = new SqlCommand($"SELECT TOP50 from dbo.Workoutplan ", conn); //TODO: add order by rating
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new WorkoutPlan
                    {
                        Name = (string)reader["Name"],
                        Kudos = (int)reader["Kudos"],
                    });
                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        public WorkoutPlan GetWorkoutPlan(string username, string planname)
        {
            WorkoutPlan result = new WorkoutPlan();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT * from dbo.Workoutplan " +
                                                    $"WHERE Name = '{planname}' AND UserID = {username}", conn); //todo innerjoins enzo , maak de query af
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new WorkoutPlan
                    {
                        Name = (string)reader["Name"],
                        Kudos = (int)reader["Kudos"],
                    };
                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            throw new NotImplementedException();
        }

    }
}
