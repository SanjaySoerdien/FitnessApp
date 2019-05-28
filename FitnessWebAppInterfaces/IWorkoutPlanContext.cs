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
        WorkoutPlan GetWorkoutPlan(string username, string planName);
        List<WorkoutPlan> SearchWorkoutsByName(string name);
        void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd);
        WorkoutPlan GetWorkoutPlanById(int id);
    }
}
