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
        public void Index_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult view = controller.New();
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Create("clara");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Showw_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Show(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddStylist_ReturnsRedirectToCorrectAction_Show()
        {
            ClientsController controller = new ClientsController();
            RedirectToActionResult newView = controller.AddStylist(12, 12) as RedirectToActionResult;
            string result = newView.ActionName;
            Assert.AreEqual(result, "Show");
        }

        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Edit(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_ReturnsCorrecttView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Update(1, "tessst");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_ReturnsCorrecttView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Delete(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteAll_ReturnsCorrecttView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.DeleteAll();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

    }
}