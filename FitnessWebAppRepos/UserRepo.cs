using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppRepos
{
    public class UserRepo
    {
        private IUserContext userContext;

        public UserRepo(IUserContext context)
        {
            userContext = context;
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
