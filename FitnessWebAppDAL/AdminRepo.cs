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

        public void AddCategory(string category)
        {
            context.AddCategory(category);
        }

        public void ChangeCategory(string categoryNew, string categoryOld)
        {
            context.ChangeCategory(categoryNew,categoryOld);
        }

        public void DeleteCategory(string category)
        {
            context.DeleteCategory(category);
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