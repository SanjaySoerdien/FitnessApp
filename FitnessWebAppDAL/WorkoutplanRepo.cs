using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class WorkoutplanRepo : IWorkoutPlanContext
    {
        private readonly IWorkoutPlanContext context;

        public WorkoutplanRepo()
        {
            context = new WorkoutPlanDAL();    
        }

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            return context.GetWorkoutPlansByUser(username);
        }

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            return context.GetTopWorkoutPlans();
        }

        public WorkoutPlan GetWorkoutPlan(string username, string planName)
        {
            return context.GetWorkoutPlan(username, planName);
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            context.AddWorkoutPlan(workoutPlanToAdd);
        }
    }
}
