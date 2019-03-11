using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{

    [TestClass]
    public class SpecialtyControllerTest
    {

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Create("tessst");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Show(6);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddStylist_ReturnsRedirectToCorrectAction_Show()
        {
            SpecialtiesController controller = new SpecialtiesController();
            RedirectToActionResult newView = controller.AddStylist(12, 12) as RedirectToActionResult;
            string result = newView.ActionName;
            Assert.AreEqual(result, "Show");
        }

        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Edit(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_ReturnsCorrecttView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Update(1, "tessst");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_ReturnsCorrecttView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Delete(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteAll_ReturnsCorrecttView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.DeleteAll();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }
    }
}
