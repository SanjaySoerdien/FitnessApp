using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    class UserDAL : IUserContext
    {
        private readonly string connectionString =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";

        public User Login(string username , string password)
        {
            User result = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 Id, Inlognaam,Wachtwoord from dbo.User WHERE Inlognaam = '{username}' and Wachtwoord = '{password}'", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = new User
                    {
                        //Username = (string)reader["Username"],
                        //Role = (string)reader["Role"]
                    };
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public List<WorkoutPlan> GetWorkoutPlans(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserInfo(string username)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
