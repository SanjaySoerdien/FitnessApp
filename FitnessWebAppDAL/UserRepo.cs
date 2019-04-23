﻿using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class UserRepo
    {
        private IUserContext userContext;

        public UserRepo()
        {
            userContext = new UserMockData();
            //userContext = new UserDAL();
        }

        public User Login(string username, string password)
        {
            return userContext.Login(username, password);
        }

        public User GetUserInfo(string username)
        {
            return userContext.GetUserInfo(username);
        }

        public void AddUser(User user)
        {
            userContext.AddUser(user);
        }
    }
}
