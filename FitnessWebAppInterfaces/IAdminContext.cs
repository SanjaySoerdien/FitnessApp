using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface IAdminContext
    {
        int AddCategory(string category);
        int ChangeCategory(string categoryNew, string categoryOld);
        int DeleteCategory(string category);
        void AddExercise(Exercise exercise); 
        void DeleteExercise(int id);
        List<Change> GetRecentChanges();
        List<Change> GetMoreChanges();
    }
}
