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
        private readonly List<WorkoutPlan> workoutPlans = new List<WorkoutPlan>();

        public WorkoutMemoryContext()
        {
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
                    Name = "Always Skip LegDate",
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
            var result = workoutPlans.First(workoutplan => workoutplan.Name.Equals(planName) && workoutplan.CreatorName.Equals(username));
            return result;
        }

        public List<WorkoutPlan> GetWorkoutPlansByUser(string username)
        {
            return (List<WorkoutPlan>) workoutPlans.Where(workoutplan => workoutplan.CreatorName.Equals(username));
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
            var result = new List<WorkoutPlan>();
            result = (List<WorkoutPlan>) workoutPlans.Where(workoutplan => workoutplan.Id.Equals(id));
            return result[0];
        }

        public void AddExerciseToWorkout(int workoutPlanId, int exerciseId, int repCount, int setCount)
        {
            throw new NotImplementedException(); //todo
        }

        public void RemoveWorkout(int id)
        {
            throw new NotImplementedException();//todo
        }

        public string AddKudoToWorkoutPlan(int workoutplanId, string nickname)
        {
            throw new NotImplementedException();
        }
    }
}