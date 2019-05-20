using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MockData;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class WorkoutplanRepo
    {
        private readonly IWorkoutPlanContext context;

        public WorkoutplanRepo()
        {
            //context = new WorkoutPlanMockData();
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

        public List<Exercise>GetWorkoutPlanExercises(string username, string planName)
        {
            return context.GetWorkoutPlanExercises(username, planName);
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            context.AddWorkoutPlan(workoutPlanToAdd);
        }
    }
}
