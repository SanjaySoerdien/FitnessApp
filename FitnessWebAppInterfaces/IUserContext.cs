using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface IUserContext
    {
        User Login(string username, string password);
        User GetUserInfo(string userName);
        void AddUser(User user);
    }
}
