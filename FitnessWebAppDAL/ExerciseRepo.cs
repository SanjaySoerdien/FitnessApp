using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.DAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class ExerciseRepo
    {
        private readonly IExerciseContext context;

        public ExerciseRepo()
        {
            context = new ExerciseDAL();
            //todo add mock data
        }
        public Exercise GetExercise(string name)
        {
            return context.GetExercise(name);
        }

        public Exercise GetExercise(int id)
        {
            return context.GetExercise(id);
        }

        public void AddExercise()
        {
            throw new NotImplementedException();
        }
    }
}
