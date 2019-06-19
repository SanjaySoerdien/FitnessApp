using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class WorkoutPlanLogic
    {
        private readonly WorkoutplanRepo workoutplanRepo;


       public WorkoutPlanLogic(IWorkoutPlanContext context)
       {
           workoutplanRepo = new WorkoutplanRepo(context);
       }


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

       public void AddWorkoutPlan (WorkoutPlan workoutPlanToAdd)
       {
           workoutplanRepo.AddWorkoutPlan(workoutPlanToAdd);
       }

       public WorkoutPlan GetWorkoutPlanById(int id)
       {
           return workoutplanRepo.GetWorkoutPlanById(id);
       }

       public List<WorkoutPlan> SearchWorkoutsByName(string name)
       {
           return workoutplanRepo.SearchWorkoutsByName(name);
       }

       public void RemoveWorkout(int id)
       {
           workoutplanRepo.RemoveWorkout(id);
       }

       public void AddExerciseToWorkout(int workoutPlanId, int exerciseId, int repCount, int setCount)
       {
           workoutplanRepo.AddExerciseToWorkout(workoutPlanId, exerciseId, repCount, setCount);
       }

       public ErrorMessage AddKudoToWorkoutPlan(int workoutplanId, string nickname)
       {
           return workoutplanRepo.AddKudoToWorkoutPlan(workoutplanId, nickname);
       }
    }
}
