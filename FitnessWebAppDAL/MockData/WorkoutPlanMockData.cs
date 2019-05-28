﻿using System;
using System.Collections.Generic;
using System.Linq;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL.MockData
{
    internal class WorkoutPlanMockData : IWorkoutPlanContext
    {
        private readonly List<WorkoutPlan> workoutPlans = new List<WorkoutPlan>();

        public WorkoutPlanMockData()
        {
            workoutPlans.Add(new WorkoutPlan
            {
                Name = "Chest day is the best day",
                CreatorName = "TestUser",
                Kudos = 40,
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "BenchPress",
                        MuscleGroup = "Chest"
                    },
                    new Exercise
                    {
                        Name = "Chest Fly",
                        MuscleGroup = "Chest"
                    },
                    new Exercise
                    {
                        Name = "Pullovers",
                        MuscleGroup = "Chest"
                    },
                    new Exercise
                    {
                        Name = "Dips",
                        MuscleGroup = "Chest"
                    }
                }
            });
            workoutPlans.Add(new WorkoutPlan
                {
                    Name = "Always Skip LegDate",
                    CreatorName = "TestAdmin",
                    Kudos = 12,
                    Exercises = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "Squat",
                            MuscleGroup = "Legs"
                        },
                        new Exercise
                        {
                            Name = "Leg press",
                            MuscleGroup = "Legs"
                        }
                    }
                }
            );
            workoutPlans.Add(new WorkoutPlan
                {
                    Name = "2nd plan for admin <3",
                    CreatorName = "TestAdmin",
                    Kudos = 12,
                    Exercises = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "360 noscope",
                            MuscleGroup = "Brain"
                        },
                        new Exercise
                        {
                            Name = "Kickflip op skateboard",
                            MuscleGroup = "LEGZZZ"
                        }
                    }
                }
            );
        }

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            return workoutPlans;
        }

        public WorkoutPlan GetWorkoutPlan(string username, string planName)
        {
            var result = workoutPlans.First(workoutplan => workoutplan.Name.Equals(planName) && workoutplan.CreatorName.Equals(username));
            return result;
        }

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            var result = workoutPlans.Where(workoutplan => workoutplan.CreatorName.Equals(username));
            return (List<WorkoutPlan>)result;
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            workoutPlans.Add(workoutPlanToAdd);
        }

        public List<WorkoutPlan> SearchWorkoutsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}