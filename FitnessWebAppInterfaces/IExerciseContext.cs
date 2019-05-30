using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface IExerciseContext
    {
        Exercise GetExercise(string name);
        Exercise GetExercise(int id);
        List<Exercise> GetTopExercises();
        List<string> GetAllCategories();
        List<Exercise> GetExercisesByCategory(string category);
        void AddExercise();
        List<Exercise> GetWorkoutPlanExercises(string planname, string nickname);

    }
}
