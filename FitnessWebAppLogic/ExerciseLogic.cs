using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppDAL;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class ExerciseLogic 
    {
        ExerciseRepo exerciseRepo = new ExerciseRepo();
        public Exercise GetExercise(string name)
        {
            return exerciseRepo.GetExercise(name);
        }

        public Exercise GetExercise(int id)
        {
            return exerciseRepo.GetExercise(id);
        }

        public void AddExercise()
        {
            throw new NotImplementedException();
        }
    }
}
