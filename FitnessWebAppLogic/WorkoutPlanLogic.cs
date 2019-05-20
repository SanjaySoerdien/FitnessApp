using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class WorkoutPlanLogic : IWorkoutPlanContext
    {
       readonly WorkoutplanRepo workoutplanRepo = new WorkoutplanRepo();

       public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
       {
           return workoutplanRepo.GetWorkoutPlansByUser(username);
       }

       public List<WorkoutPlan> GetTopWorkoutPlans()
       {
           return workoutplanRepo.GetTopWorkoutPlans();
       }

       public List<Exercise> GetWorkoutPlanExercises(string username, string planName)
       {
           return workoutplanRepo.GetWorkoutPlanExercises(username,planName);
       }

       public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
       {
           throw new NotImplementedException();
       }
    }
}
