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

        public UserLogic(IUserContext context)
        {
            userRepo = new UserRepo(context);
        }

        public User Login(string username,string password)
        {
            return userRepo.Login(username,password);
        }

        public User GetUserInfo(string username)
        {
            return userRepo.GetUserInfo(username);
        }

        public void AddUser(User user)
        {
            userRepo.AddUser(user);
        }
    }
}
