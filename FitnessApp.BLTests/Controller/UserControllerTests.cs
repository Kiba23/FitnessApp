using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "female";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 55;
            var height = 175;

            // Act
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);

            var controllerCompare = new UserController(userName);

            // Assert
            Assert.AreEqual(controller.CurrentUser.Name, controllerCompare.CurrentUser.Name);
            Assert.AreEqual(controller.CurrentUser.Gender.Name, controllerCompare.CurrentUser.Gender.Name);
            Assert.AreEqual(controller.CurrentUser.BirthDate, controllerCompare.CurrentUser.BirthDate);
            Assert.AreEqual(controller.CurrentUser.Weight, controllerCompare.CurrentUser.Weight);
            Assert.AreEqual(controller.CurrentUser.Height, controllerCompare.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}