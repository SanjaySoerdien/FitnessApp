﻿using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppRepos
{
    public class WorkoutplanRepo
    {
        private readonly IWorkoutPlanContext context;

        public WorkoutplanRepo(IWorkoutPlanContext workoutPlanContext)
        {
            this.context = workoutPlanContext;
        }

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            return context.GetWorkoutPlansByUser(username);
        }

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            return context.GetTopWorkoutPlans();
        }

        public WorkoutPlan GetWorkoutPlanExercises(string username, string planName)
        {
            return context.GetWorkoutPlan(username, planName);
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            context.AddWorkoutPlan(workoutPlanToAdd);
        }

        public List<WorkoutPlan> SearchWorkoutsByName(string name)
        {
            return context.SearchWorkoutsByName(name);
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            return context.GetWorkoutPlanById(id);
        }

        public void RemoveWorkout(int id)
        {
            context.RemoveWorkout(id);
        }
        public void AddExerciseToWorkout(int workoutPlanId, int exerciseId, int repCount, int setCount)
        {
            context.AddExerciseToWorkout(workoutPlanId, exerciseId, repCount, setCount);
        }

        public ErrorMessage AddKudoToWorkoutPlan(int workoutplanId, string nickname)
        {
            return context.AddKudoToWorkoutPlan(workoutplanId, nickname);
        }
    }
}
