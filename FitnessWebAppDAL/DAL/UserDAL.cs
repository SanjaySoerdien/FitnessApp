using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Login", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Username", username));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (password != (string)reader["Password"])
                        {
                            return result;
                        }
                        result = new User
                        {
                            Username = (string)reader["Username"],
                            Role = (string)reader["Role"],
                            Nickname = (string)reader["Nickname"]
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
        public User GetUserInfo(string nickname)
        {
            User result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetUserInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", nickname));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new User
                        {
                            Role = (string) reader["Role"],
                            Nickname = (string) reader["Nickname"]
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

        public void AddUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nickname", user.Nickname));
                    cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
                    cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
