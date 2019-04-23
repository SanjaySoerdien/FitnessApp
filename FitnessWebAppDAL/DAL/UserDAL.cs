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
                SqlCommand command = new SqlCommand($"SELECT Inlognaam,Wachtwoord, from dbo.User " +
                                                    $"WHERE Inlognaam = '{username}' and Wachtwoord = '{password}'", conn); //ToDo Add roles to query
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (password != (string) reader["Password"])
                    {
                        return result;
                    }
                    result = new User
                    {
                        Username = (string)reader["Username"],
                        //Role = (string)reader["Role"]
                    };
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public User GetUserInfo(string username)
        {
            User result = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT * from dbo.User " +
                                                    $"WHERE Inlognaam = '{username}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new User
                    {
                        //todo Write info to user when decided on what info
                        //Role = (string)reader["Role"]
                    };
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command =
                    new SqlCommand(
                        $"INSERT INTO User (Nickname, Username, Password) VALUES({user.Nickname}, {user.Username}, {user.Password});");

                if (command.ExecuteNonQuery() > 0)
                {
                    //ToDo Detect if functional?
                }
                conn.Close();
            }
        }
    }
}
