using System;
using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppMemContexts
{
    public class UserMemoryContext : IUserContext
    {

        private static List<User> users = new List<User>();

        public UserMemoryContext()
        {
            users.Add(new User
            {
                Nickname = "TestAdmin",
                Username = "admin",
                Password = "1234",
                Role = "Member"
            });

            users.Add(new User
            {
                Nickname = "TestUser",
                Username = "user",
                Password = "1234",
                Role = "Member"
            });
        }

        public User Login(string username, string password)
        {
            User result;
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
                Role = "Member",
            };
        }

        public void AddUser(User user)
        {
            user.Role = "Member";
            users.Add(user);
        }
    }
}
