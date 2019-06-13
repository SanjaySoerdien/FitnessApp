using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class AdminRepo
    {
        private IAdminContext context;

        public AdminRepo()
        {
            context = new AdminDal();
            //todo Add mock data voor unit tests
        }

        public int AddCategory(string category)
        {
            return context.AddCategory(category);
        }

        public int ChangeCategory(string categoryNew, string categoryOld)
        {
            return context.ChangeCategory(categoryNew,categoryOld);
        }

        public int DeleteCategory(string category)
        {
            return context.DeleteCategory(category);
        }

        public void AddExercise(Exercise exercise)
        {
            context.AddExercise(exercise);
        }

        public void DeleteExercise(int id)
        {
            context.DeleteExercise(id);
        }

        public List<Change> GetRecentChanges()
        {
            return context.GetRecentChanges();
        }

        public List<Change> GetMoreChanges()
        {
            return context.GetMoreChanges();
        }
    }
}