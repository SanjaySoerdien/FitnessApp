using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;
using FitnessWebAppModels.Enums;

namespace FitnessWebAppDAL
{
    class UserMockData : IUserContext
    {

        private List<User> users = new List<User>();


        public UserMockData()
        {
            users.Add(new User
            {
                Nickname = "TestAdmin",
                Username = "admin",
                Password = "1234",
                Role = Role.Admin
            });

            users.Add(new User
            {
                Nickname = "TestUser",
                Username = "user",
                Password = "1234",
                Role = Role.Member
            });
        }
        public User Login(string username, string password)
        {
            User result = new User();
            result = null;

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return new User
                    {
                        Nickname = user.Nickname,
                        Username = user.Username,
                        Role = user.Role
                    };
                }
            }
            return result;
        }

        public List<WorkoutPlan> GetWorkoutPlans(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserInfo(string username)
        {
            return new User
            {
                Nickname = "MockName",
                Role = Role.Member,
            };
        }

        public void AddUser(User user)
        {
            user.Role = Role.Member;
            users.Add(user);
        }
    }
}
