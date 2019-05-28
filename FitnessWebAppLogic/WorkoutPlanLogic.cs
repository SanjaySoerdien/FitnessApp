using System;
using System.Collections.Generic;
using System.Dynamic;
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

       public WorkoutPlan GetWorkoutPlan(string username, string planName)
       {
           return workoutplanRepo.GetWorkoutPlanExercises(username,planName);
       }

       public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
       {
           throw new NotImplementedException();
       }

       public List<WorkoutPlan> SearchWorkoutsByName(string name)
       {
           return workoutplanRepo.SearchWorkoutsByName(name);
       }
    }
}
