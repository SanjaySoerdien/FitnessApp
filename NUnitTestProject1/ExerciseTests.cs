using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MemoryContexts;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using NUnit.Framework;

namespace FitnessWebAppTests
{
    class ExerciseTests
    {
        private ExerciseLogic exerciseLogic;
        [SetUp]
        public void Setup()
        {
            exerciseLogic = new ExerciseLogic(new ExerciseMemoryContext());
        }

        [Test]
        public void AddKudoToExercise_IdIs3_ReturnStringWithNumber()
        {
            var result = exerciseLogic.AddKudoToExercise(3, "UnitTest");

            Assert.That(Convert.ToInt32(result), Is.GreaterThan(0));
        }

        [Test]
        public void GetTopExercises_ReturnListBiggerThan0()
        {
            var result = exerciseLogic.GetTopExercises();
            Assert.That(result.Count, Is.GreaterThan(0));
        }
        [Test]
        public void GetTopExercises_ReturnListOfStrings()
        {
            var result = exerciseLogic.GetAllCategories();

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetAllCategories_ReturnListOf4()
        {
            var assumption = new List<string>
            {
                "Arms",
                "Chest",
                "Triceps",
                "Back"
            };
            var result = exerciseLogic.GetAllCategories();
            Assert.That(result, Is.EqualTo(assumption));
        }

        [Test]
        public void GetExerciseById_IdIs1_ReturnExercise()
        {
            var assumption = new Exercise
            {
                Name = "Dab",
                Description = "Flick your hands up real fast",
                Id = 1,
                Kudos = 1,
                MuscleGroup = "Arms",
            };
            var result = exerciseLogic.GetExercise(1);
            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(assumption.Name));
                Assert.That(result.Kudos, Is.EqualTo(assumption.Kudos));
                Assert.That(result.MuscleGroup, Is.EqualTo(assumption.MuscleGroup));
                Assert.That(result.Description, Is.EqualTo(assumption.Description));
            });
        }

        [Test]
        public void GetExerciseByName_NameIsDips_ReturnExercise()
        {
            var assumption = new Exercise
            {
                Name = "Dips",
                Description = "do the thing",
                Id = 10,
                Kudos = 122,
                MuscleGroup = "Chest"
            };
            var result = exerciseLogic.GetExercise("Dips");
            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(assumption.Name));
                Assert.That(result.Kudos, Is.EqualTo(assumption.Kudos));
                Assert.That(result.MuscleGroup, Is.EqualTo(assumption.MuscleGroup));
                Assert.That(result.Description, Is.EqualTo(assumption.Description));
            });
        }


      
    }
}
