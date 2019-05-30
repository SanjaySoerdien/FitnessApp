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

        public WorkoutPlan GetWorkoutPlan(string nickname, string planname)
        {
            WorkoutPlan result = new WorkoutPlan();
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
                }
                reader.Close();
                conn.Close();
            }

           

            result.Exercises = exerciseDAL.GetWorkoutPlanExercises(planname, nickname);
            result.Comments = commentDAL.GetCommentsByWorkoutplan(result.Id);

            return result;
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            WorkoutPlan result = new WorkoutPlan();
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
                }
                reader.Close();
                conn.Close();
            }
            result.Exercises = exerciseDAL.GetWorkoutPlanExercises(result.Name, result.CreatorName);//TODO maybe change to ID?
            result.Comments = commentDAL.GetCommentsByWorkoutplan(result.Id);
            return result;
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            throw new NotImplementedException();
            //TODO Make dis
        }

        public List<WorkoutPlan> SearchWorkoutsByName(string name)
        {
            List<WorkoutPlan> result = new List<WorkoutPlan>();
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
                        Kudos = (int)reader["Kudo"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
    }
}
