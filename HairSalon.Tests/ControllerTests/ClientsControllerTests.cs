using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {



        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
            ClientsController controller = new ClientsController();

            // Act
            ActionResult view = controller.New(3);

            // Assert
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }


        [TestMethod]
        public void Showw_ReturnsCorrectView_True()
        {
            // Arrange
            ClientsController controller = new ClientsController();

            // Act
            ActionResult newView = controller.Show(1, 2);

            // Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }


        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
            // Arrange
            ClientsController controller = new ClientsController();

            // Act
            ActionResult newView = controller.Edit(1, 2);

            // Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }


        [TestMethod]
        public void Update_ReturnsCorrecttView_True()
        {
            // Arrange
            ClientsController controller = new ClientsController();

            // Act
            ActionResult newView = controller.Update(1, 2, "tessst");

            // Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }



    }
}