﻿using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;
using FitnessWebAppRepos;

namespace FitnessWebAppLogic
{
    public class ExerciseLogic
    {
        private ExerciseRepo exerciseRepo;


        public ExerciseLogic(IExerciseContext exerciseContext)
        {
            exerciseRepo = new ExerciseRepo(exerciseContext);
        }

        public Exercise GetExercise(string name)
        {
            return exerciseRepo.GetExercise(name);
        }

        public Exercise GetExercise(int id)
        {
            return exerciseRepo.GetExercise(id);
        }

        public List<Exercise> GetTopExercises()
        {
            return exerciseRepo.GetTopExercises();
        }

        public List<string> GetAllCategories()
        {
            return exerciseRepo.GetAllCategories();
        }

        public List<Exercise> GetExercisesByCategory(string category)
        {
            return exerciseRepo.GetExercisesByCategory(category);
        }

        public ErrorMessage AddKudoToExercise(int exerciseId, string nickname)
        {
            return exerciseRepo.AddKudoToExercise(exerciseId, nickname);
        }
    }
}
