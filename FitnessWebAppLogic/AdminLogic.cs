using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class AdminLogic
    {
        private AdminRepo adminRepo = new AdminRepo();

        public void AddCategory(string category)
        {
            adminRepo.AddCategory(category);
        }

        public void ChangeCategory(string categoryNew, string categoryOld)
        {
            adminRepo.ChangeCategory(categoryNew, categoryOld);
        }

        public void DeleteCategory(string category)
        {
            adminRepo.DeleteCategory(category);
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
