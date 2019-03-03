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
        //Arrange
        string name = "Test Stylist";
        Stylist newStylist = new Stylist(name);

        //Act
        string result = newStylist.GetName();

        //Assert
        Assert.AreEqual(name, result);
        }

    // [TestMethod]
    //     public void GetId_ReturnsStylistId_Int()
    //     {
    //     //Arrange
    //     string name = "Test Stylist";
    //     Stylist newStylist = new Stylist(name);

    //     //Act
    //     int result = newStylist.GetId();

    //     //Assert
    //     Assert.AreEqual(1, result);
    //     }
    
    //  [TestMethod]
    //     public void GetAll_ReturnsAllStylistObjects_StylistList()
    //     {
    //     //Arrange
    //     string name01 = "Work";
    //     string name02 = "School";
    //     Stylist newStylist1 = new Stylist(name01);
    //     Stylist newStylist2 = new Stylist(name02);
    //     List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

    //     //Act
    //     List<Stylist> result = Stylist.GetAll();

    //     //Assert
    //     CollectionAssert.AreEqual(newList, result);
    //     }

    // [TestMethod]
    //     public void Find_ReturnsCorrectStylist_Stylist()
    //     {
    //     //Arrange
    //     string name01 = "Work";
    //     string name02 = "School";
    //     Stylist newStylist1 = new Stylist(name01);
    //     Stylist newStylist2 = new Stylist(name02);

    //     //Act
    //     Stylist result = Stylist.Find(2);

    //     //Assert
    //     Assert.AreEqual(newStylist2, result);
    //     }

    [TestMethod]
        public void GetClients_ReturnsEmptyClientList_ClientList()
        {
        //Arrange
        string name = "Work";
        Stylist newCategory = new Stylist(name);
        List<Client> newList = new List<Client> { };

        //Act
        List<Client> result = newCategory.GetClients();

        //Assert
        CollectionAssert.AreEqual(newList, result);
        }

        
    [TestMethod]
        public void AddClient_AssociatesClientWithStylist_ClientList()
        {
            //Arrange
            string description = "Walk the dog.";
            Client newClient = new Client(description, 1);
            List<Client> newList = new List<Client> { newClient };
            string name = "Work";
            Stylist newStylist = new Stylist(name);
            newStylist.AddClient(newClient);

            //Act
            List<Client> result = newStylist.GetClients();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

          [TestMethod]
            public void GetAll_StylistsEmptyAtFirst_List()
            {
                //Arrange, Act
                int result = Stylist.GetAll().Count;

                //Assert
                Assert.AreEqual(0, result);
            }

    }
}