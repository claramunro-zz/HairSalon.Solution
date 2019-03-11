using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=clara_munro_test;";
        }

        public void Dispose()
        {
            Stylist.ClearAll();
            Client.ClearAll();
            Specialty.ClearAll();
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            Stylist newStylist = new Stylist("test stylist");
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            string name = "Test Stylist";
            Stylist newStylist = new Stylist(name);
            string result = newStylist.GetName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllStylistObjects_StylistList()
        {
            string name01 = "Work";
            string name02 = "School";
            Stylist newStylist1 = new Stylist(name01);
            newStylist1.Save();
            Stylist newStylist2 = new Stylist(name02);
            newStylist2.Save();
            List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsStylistInDatabase_Stylist()
        {
            Stylist testStylist = new Stylist("Household chores");
            testStylist.Save();
            Stylist foundStylist = Stylist.Find(testStylist.GetId());
            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void GetClients_ReturnsEmptyClientList_ClientList()
        {
            string name = "Work";
            Stylist newStylist = new Stylist(name);
            List<Client> newList = new List<Client> { };
            List<Client> result = newStylist.GetClients();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_List()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
            Stylist firstStylist = new Stylist("Household chores");
            Stylist secondStylist = new Stylist("Household chores");
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            Stylist testStylist = new Stylist("Household chores");
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist> { testStylist };
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
            Stylist testStylist = new Stylist("Household chores");
            testStylist.Save();
            Stylist savedStylist = Stylist.GetAll()[0];
            int result = savedStylist.GetId();
            int testId = testStylist.GetId();
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void GetClients_ReturnsAllStylistClients_ClientList()
        {
            Stylist testStylist = new Stylist("Household chores");
            testStylist.Save();
            Client testClient1 = new Client("Mow the lawn");
            testClient1.Save();
            Client testClient2 = new Client("Buy plane ticket");
            testClient2.Save();
            testStylist.AddClient(testClient1);
            List<Client> savedClients = testStylist.GetClients();
            List<Client> testList = new List<Client> { testClient1 };
            CollectionAssert.AreEqual(testList, savedClients);
        }

        [TestMethod]
        public void Delete_DeletesStylistAssociationsFromDatabase_StylistList()
        {
            Client testClient = new Client("Mow the lawn");
            testClient.Save();
            string testName = "Home stuff";
            Stylist testStylist = new Stylist(testName);
            testStylist.Save();
            testStylist.AddClient(testClient);
            testStylist.Delete();
            List<Stylist> resultClientStylists = testClient.GetStylists();
            List<Stylist> testClientStylists = new List<Stylist> { };
            CollectionAssert.AreEqual(testClientStylists, resultClientStylists);
        }

        [TestMethod]
        public void Test_AddClient_AddsClientToStylist()
        {
            Stylist testStylist = new Stylist("Household chores");
            testStylist.Save();
            Client testClient = new Client("Mow the lawn");
            testClient.Save();
            Client testClient2 = new Client("Water the garden");
            testClient2.Save();
            testStylist.AddClient(testClient);
            testStylist.AddClient(testClient2);
            List<Client> result = testStylist.GetClients();
            List<Client> testList = new List<Client> { testClient, testClient2 };
            CollectionAssert.AreEqual(testList, result);
        }
    }
}