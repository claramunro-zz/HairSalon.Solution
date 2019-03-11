using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=clara_munro_test;";
        }
        public void Dispose()
        {
            Specialty.ClearAll();
            Stylist.ClearAll();
        }

        [TestMethod]
        public void SpecialtyConstructor_CreatesInstanceSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("clara", 1);
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }

        [TestMethod]
        public void GetStyle_ReturnsStyle_String()
        {
            string style = "clara";
            int id = 0;
            Specialty newSpecialty = new Specialty(style, id);
            string result = newSpecialty.GetStyle();
            Assert.AreEqual(style, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyDB()
        {
            string name01 = "clara";
            string name02 = "zoey";
            Specialty newSpecialty1 = new Specialty(name01);
            newSpecialty1.Save();
            Specialty newSpecialty2 = new Specialty(name02);
            newSpecialty2.Save();
            List<Specialty> list12 = new List<Specialty> { newSpecialty1, newSpecialty2 };
            List<Specialty> result = Specialty.GetAll();
            CollectionAssert.AreEqual(list12, result);
        }

        [TestMethod]
        public void Find_ReturnsSpecialtyDB_Specialty()
        {
            Specialty test = new Specialty("clara");
            test.Save();
            Specialty specialtyResult = Specialty.Find(test.GetId());
            Assert.AreEqual(test, specialtyResult);
        }


        // get stylists



        [TestMethod]
        public void Equals_ReturnsTrueIfStylesAreSame_Specialty()
        {
            Specialty firstSpecialty = new Specialty("test");
            Specialty secondSpecialty = new Specialty("test");
            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }


         [TestMethod]
        public void Save_SavesSpecialtyToDatabase_StylistList()
        {
            Specialty testStylist = new Specialty("test");
            testStylist.Save();
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty>{testStylist};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Edit_UpdatesClientInDatabase_String()
        {
            Specialty testSpecialty = new Specialty("Walk the Dog");
            testSpecialty.Save();
            string secondDescription = "Mow the lawn";
            testSpecialty.Edit(secondDescription);
            string result = Specialty.Find(testSpecialty.GetId()).GetStyle();
            Assert.AreEqual(secondDescription, result);
        }

        [TestMethod]
        public void Test_AddStylist_AddsStylistToSpecialist()
        {
            Stylist testStylist = new Stylist("test");
            testStylist.Save();
            Specialty testSpecialty = new Specialty("clara");
            testSpecialty.Save();
            Specialty testSpecialty2 = new Specialty("clara2");
            testSpecialty2.Save();
            testStylist.AddSpecialty(testSpecialty);
            testStylist.AddSpecialty(testSpecialty2);
            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty> { testSpecialty, testSpecialty2 };
            CollectionAssert.AreEqual(testList, result);
        }


        // [TestMethod]
        // public void Delete_DeletesStylistAssociationsFromDatabase_StylistList()
        // {

        //     Specialty testSpecialty = new Specialty("zoey2");
        //     testSpecialty.Save();
        //     Specialty testSpecialty2 = new Specialty("clara");
        //     testSpecialty2.Save();
            
        //     testSpecialty.AddStylist(testSpecialty);
        //     testStylist.Delete();

        //     List<Stylist> resultClientStylists = testClient.GetStylists();
        //     List<Stylist> testClientStylists = new List<Stylist> { };

        //     //Assert
        //     CollectionAssert.AreEqual(testClientStylists, resultClientStylists);
        // }


        // clearAll


    }
}