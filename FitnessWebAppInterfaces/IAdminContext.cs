using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface IAdminContext
    {
        void AddCategory(string category);
        void ChangeCategory(string categoryNew, string categoryOld);
        void DeleteCategory(string category);
        void AddExercise(Exercise exercise); 
        void DeleteExercise(int id);
        List<Change> GetRecentChanges();
        List<Change> GetMoreChanges();
    }
}
