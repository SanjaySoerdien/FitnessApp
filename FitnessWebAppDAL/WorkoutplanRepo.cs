using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MemoryContexts;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class WorkoutplanRepo
    {
        private readonly IWorkoutPlanContext context;

        public WorkoutplanRepo()
        {
            context = new WorkoutPlanDAL();
            //context = new WorkoutMemoryContext();
        }

        public WorkoutplanRepo(IWorkoutPlanContext workoutPlanContext)
        {
            context = new WorkoutMemoryContext();
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

        public string AddKudoToWorkoutPlan(int workoutplanId, string nickname)
        {
            return context.AddKudoToWorkoutPlan(workoutplanId, nickname);
        }
    }
}
