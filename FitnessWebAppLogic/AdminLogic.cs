using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;
using FitnessWebAppRepos;

namespace FitnessWebAppLogic
{
    public class AdminLogic
    {
        private AdminRepo adminRepo;

        public AdminLogic(IAdminContext context)
        {
            adminRepo = new AdminRepo(context);
        }

        public int AddCategory(string category)
        {
            return adminRepo.AddCategory(category);
        }

        public int ChangeCategory(string categoryNew, string categoryOld)
        {
            return adminRepo.ChangeCategory(categoryNew, categoryOld);
        }

        public int DeleteCategory(string category)
        {
            return adminRepo.DeleteCategory(category);
        }

        public void AddExercise(Exercise exercise)
        {
            adminRepo.AddExercise(exercise);
        }

        public void DeleteExercise(int id)
        {
            adminRepo.DeleteExercise(id);
        }

        public List<Change> GetRecentChanges()
        {
            return adminRepo.GetRecentChanges();
        }

        public List<Change> GetMoreChanges()
        {
            return adminRepo.GetMoreChanges();
        }
    }
}
