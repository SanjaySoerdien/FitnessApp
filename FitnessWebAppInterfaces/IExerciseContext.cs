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
        void AddExercise(Exercise exercise);
        void RemoveExercise(int id);
        List<Exercise> GetWorkoutPlanExercises(string planname, string nickname);

    }
}
