using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface IWorkoutPlanContext
    {
        List<WorkoutPlan> GetWorkoutPlansByUser(string username);
        List<WorkoutPlan> GetTopWorkoutPlans();
        List<Exercise> GetWorkoutPlanExercises(string username, string planName);
        void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd);
    }
}
