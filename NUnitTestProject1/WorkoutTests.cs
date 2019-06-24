using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppLogic;
using FitnessWebAppMemContexts;
using NUnit.Framework;

namespace FitnessWebAppTests
{
    public class WorkoutTests
    {
        private WorkoutPlanLogic workoutPlanLogic;
        [SetUp]
        public void Setup()
        {
            workoutPlanLogic = new WorkoutPlanLogic(new WorkoutMemoryContext());
        }

        [Test]
        public void GetWorkoutPlanById_IdIs4_ReturnWorkout()
        {
            var result = workoutPlanLogic.GetWorkoutPlanById(4);
            Assert.That(result.Id.Equals(4));
        }

        [Test]
        public void GetWorkoutPlanById_IdIs40_ReturnNull()
        {
            var result = workoutPlanLogic.GetWorkoutPlanById(40);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetWorkoutPlansByUser_UserNameIsTestAdmin_ReturnList()
        {
            var result = workoutPlanLogic.GetWorkoutPlansByUser("TestUser");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetWorkoutPlansByUser_UserNameIsNonExistingUser_ReturnNull()
        {
            var result = workoutPlanLogic.GetWorkoutPlansByUser("NonExistingUser");
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetWorkoutPlan_UserNameIsGood_ReturnWorkoutplan()
        {
            string username = "TestUser";
            string planname = "Always Skip Legday";
            var result = workoutPlanLogic.GetWorkoutPlan(username, planname);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(result.Name, planname);
                Assert.AreEqual(result.CreatorName, username);
            });
        }

        [Test]
        public void GetWorkoutPlan_UserNameIsNonExistingUser_ReturnWorkoutplan()
        {
            var result = workoutPlanLogic.GetWorkoutPlan("NonExistingUser","NonExistingNames");
            Assert.That(result, Is.Null);
        }
    }
}
