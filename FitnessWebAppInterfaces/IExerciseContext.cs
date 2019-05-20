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
        void AddExercise();

    }
}
