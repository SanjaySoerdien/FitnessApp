using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MemoryContexts;
using FitnessWebAppLogic;
using NUnit.Framework;

namespace FitnessWebAppTests
{
    public class IntegrationTests
    {
        private UserLogic userlogic;
        private WorkoutPlanLogic workoutPlanLogic;
        private ExerciseLogic exerciseLogic;
        [SetUp]
        public void Setup()
        {
            userlogic = new UserLogic();
            workoutPlanLogic = new WorkoutPlanLogic();
            exerciseLogic = new ExerciseLogic();
        }

        [Test]
        public void Login_UserNotNull_ReturnUser()
        {
            var result = userlogic.Login("Sanjay", "1234");
            Assert.That(result, !Is.Null);
        }

        [Test]
        public void GetTopWorkouts_ReturnList()
        {
            var result = workoutPlanLogic.GetTopWorkoutPlans();
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void SearchWorkoutsByName_StringIsChe_ReturnList()
        {
            var result = workoutPlanLogic.SearchWorkoutsByName("che");
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void SearchWorkoutsByName_LongString_ReturnEmptyList()
        {
            var result = workoutPlanLogic.SearchWorkoutsByName("x66xq5dsa23a");
            Assert.That(result, Is.Empty);
        }
    }
}
