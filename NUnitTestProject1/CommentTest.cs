using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MemoryContexts;
using FitnessWebAppLogic;
using NUnit.Framework;

namespace FitnessWebAppTests
{
    class CommentTest
    {
        private CommentLogic commentLogic;
       [SetUp]
        public void Setup()
        {
            commentLogic = new CommentLogic(new CommentMemoryContext());
        }

        [Test]
        public void AddKudoToExercise_IdIs3_ReturnStringWithNumber()
        {
            var result = commentLogic.AddKudoToComment(3,"TestUser");

            Assert.That(Convert.ToInt32(result), Is.GreaterThan(0));
        }

    }
}
