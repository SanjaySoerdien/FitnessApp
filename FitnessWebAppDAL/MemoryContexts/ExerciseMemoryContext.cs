﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL.MemoryContexts
{
    public class ExerciseMemoryContext : IExerciseContext
    {
        private List<Exercise> exercises = new List<Exercise>();
        private CommentMemoryContext commentContext = new CommentMemoryContext();

        public ExerciseMemoryContext()
        {
            exercises.Add(new Exercise
            {
                Name  = "Dab",
                Description = "Flick your hands up real fast",
                Id = 1,
                Kudos = 1,
                MuscleGroup = "Arms",
            });
            exercises.Add(new Exercise
            {
                Name = "Bench press",
                Description = "press the bar up!",
                Id = 2,
                Kudos = 2,
                MuscleGroup = "Chest",
            });
            exercises.Add(new Exercise
            {
                Name = "Leg Press",
                Description = "Pressing movement with your legs",
                Id = 3,
                Kudos = 3,
                MuscleGroup = "Legs",
            });
            exercises.Add(new Exercise
            {
                Name = "Bicep curls",
                Description = "Flex them muscles bro",
                Id = 4,
                Kudos = 44,
                MuscleGroup = "Arms",
            });
            exercises.Add(new Exercise
            {
                Name = "Lat pulldown",
                Description = "Pull down a bar and stuff",
                Id = 5,
                Kudos = 55,
                MuscleGroup = "Back",
            });
            exercises.Add(new Exercise
            {
                Name = "Tricepthing",
                Description = "do the thing",
                Id = 6,
                Kudos = 66,
                MuscleGroup = "Triceps",
            });

            exercises.Add(new Exercise
            {
                Name = "BenchPress",
                Description = "do the thing",
                Id = 7,
                Kudos = 77,
                MuscleGroup = "Chest"
            });
            exercises.Add(new Exercise
            {
                Name = "Chest Fly",
                Description = "do the thing",
                Id = 8,
                Kudos = 88,
                MuscleGroup = "Chest"
            });
            exercises.Add(new Exercise
            {
                Name = "Pullovers",
                Description = "do the thing",
                Id = 9,
                Kudos = 99,
                MuscleGroup = "Chest"
            });
            exercises.Add(new Exercise
            {
                Name = "Dips",
                Description = "do the thing",
                Id = 10,
                Kudos = 122,
                MuscleGroup = "Chest"
            });
        }

        public Exercise GetExercise(string name)
        {
            List<Exercise> result = (List<Exercise>) exercises.Where(n => n.Name.Equals(name));
            return result[0];
        }

        public Exercise GetExercise(int id)
        {
            List<Exercise> result = (List<Exercise>) exercises.Where(n => n.Id.Equals(id));
            return result[0];
        }

        public List<Exercise> GetTopExercises()
        {
            return exercises;
        }

        public List<string> GetAllCategories()
        {
            var result = new List<string>
            {
                "Arms",
                "Chest",
                "Triceps",
                "Back"
            };
            return result;
        }

        public List<Exercise> GetExercisesByCategory(string category)
        {
            return (List<Exercise>) exercises.Where(n => n.MuscleGroup.Equals(category));
        }

        public List<Exercise> GetWorkoutPlanExercises(string planname, string nickname)
        {
            List<Exercise> result = new List<Exercise>();
            result.Add(exercises[0]);
            result.Add(exercises[1]);
            result.Add(exercises[4]);
            result.Add(exercises[5]);
            return result;
        }

        public string AddKudoToExercise(int exerciseId, string nickname)
        {
            List<Exercise> result = (List<Exercise>)exercises.Select(n => n.Id.Equals(exerciseId));
            result[0].Kudos++;
            return result[0].Kudos.ToString();
        }
    }
}