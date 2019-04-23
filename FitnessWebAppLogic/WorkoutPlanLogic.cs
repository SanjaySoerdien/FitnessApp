using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class WorkoutPlanLogic
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

       public WorkoutPlan GetWorkoutPlan(string username, string planname)
       {
           return GetWorkoutPlan(username, planname);
       }
    }
}
