using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class UserLogic 
    {
        private readonly UserRepo userRepo;

        public UserLogic()
        {
            userRepo = new UserRepo();
        }

        public User Login(string username,string password)
        {
            return userRepo.Login(username,password);
        }

        public User GetUserInfo(string username)
        {
            return userRepo.GetUserInfo(username);
        }

        public List<WorkoutPlan> GetWorkoutPlans(User user)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            userRepo.AddUser(user);
        }
    }
}
