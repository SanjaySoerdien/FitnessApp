using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using NUnit.Framework;

namespace FitnessWebAppTests
{
    
    public class UserTests
    {
        private UserLogic userlogic;
        [SetUp]
        public void Setup()
        {
            userlogic = new UserLogic(new UserMemoryContext());
        }

        [Test]
        public void Login_UserNotNull_ReturnUser()
        {
            var result = userlogic.Login("admin", "1234");
            Assert.That(result, !Is.Null);
        }

        [Test]
        public void Login_UserNull_ReturnUser()
        {
            var result = userlogic.Login("admin", "1236");
            Assert.That(result, Is.Null);
        }
    }
}