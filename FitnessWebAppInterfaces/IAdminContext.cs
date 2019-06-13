using System;
using System.Collections.Generic;
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
    }
}
