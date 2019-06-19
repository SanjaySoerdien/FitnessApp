using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL.MemoryContexts
{
    public class WorkoutMemoryContext : IWorkoutPlanContext
    {
        private readonly List<WorkoutPlan> workoutPlans;

        public WorkoutMemoryContext()
        {
            workoutPlans = new List<WorkoutPlan>();
            workoutPlans.Add(new WorkoutPlan
            {
                Id = 0,
                Name = "Chest day is the best day",
                CreatorName = "TestUser",
                Kudos = 40,
                CategoryName = "Flex"
            });
            workoutPlans.Add(new WorkoutPlan
                {
                    Id = 1,
                    Name = "Always Skip Legday",
                    CreatorName = "TestUser",
                    Kudos = 12,
                    CategoryName = "Chest"
                }
            );
            workoutPlans.Add(new WorkoutPlan
                {
                    Id = 2,
                    Name = "2nd plan for admin <3",
                    CreatorName = "TestAdmin",
                    Kudos = 18,
                    CategoryName = "Headday"
                }
            );
            workoutPlans.Add(new WorkoutPlan
                {
                    Id = 3,
                    Name = "3rd plan for admin <3",
                    CreatorName = "TestAdmin",
                    Kudos = 12,
                    CategoryName = "Bulk"
                }
            );
            workoutPlans.Add(new WorkoutPlan
                {
                    Id = 4,
                    Name = "4th plan for admin <3",
                    CreatorName = "TestAdmin",
                    Kudos = 44,
                    CategoryName = "Mass bulking for sumo wrestler"
                }
            );
        }

        public List<WorkoutPlan> GetTopWorkoutPlans()
        {
            return workoutPlans;
        }

        public WorkoutPlan GetWorkoutPlan(string username, string planName)
        {
            var result = workoutPlans.Find(workoutplan => workoutplan.Name.Equals(planName) && workoutplan.CreatorName.Equals(username));
            return result;
        }

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            return workoutPlans.Where(workoutplan => workoutplan.CreatorName.Equals(username)).ToList();
        }

        public void AddWorkoutPlan(WorkoutPlan workoutPlanToAdd)
        {
            workoutPlans.Add(workoutPlanToAdd);
        }

        public List<WorkoutPlan> SearchWorkoutsByName(string name)
        {
            return (List<WorkoutPlan>) workoutPlans.Where(workoutplan => workoutplan.Name.Equals(name));
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            
            var result = workoutPlans.Where(workoutplan => workoutplan.Id.Equals(id)).ToList();
            if (result.Count > 0)
            {
                return result.First();
            }
            return null;
        }

        public void AddExerciseToWorkout(int workoutPlanId, int exerciseId, int repCount, int setCount)
        {
            throw new NotImplementedException(); 
        }

        public void RemoveWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public ErrorMessage AddKudoToWorkoutPlan(int workoutplanId, string nickname)
        {
            throw new NotImplementedException();
        }
    }
}