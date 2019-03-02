using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Client newClient = new Client(description);

      //Act
      string result = newClient.GetDescription();

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Client newClient = new Client(description);

      //Act
      string updatedDescription = "Do the dishes";
      newClient.SetDescription(updatedDescription);
      string result = newClient.GetDescription();

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
      {
        // Arrange
        List<Client> newList = new List<Client> { };

        // Act
        List<Client> result = Client.GetAll();

        // Assert
        CollectionAssert.AreEqual(newList, result);
      }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
      {
        //Arrange
        string description01 = "Zoey";
        string description02 = "Clara";
        Client newClient1 = new Client(description01);
        Client newClient2 = new Client(description02);
        List<Client> newList = new List<Client> { newClient1, newClient2 };

        //Act
        List<Client> result = Client.GetAll();

        //Assert
        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
        {
          //Arrange
          string description = "Walk the dog.";
          Client newClient = new Client(description);

          //Act
          int result = newClient.GetId();

          //Assert
          Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectClient_Client()
          {
            //Arrange
            string description01 = "Walk the dog";
            string description02 = "Wash the dishes";
            Client newItem1 = new Client(description01);
            Client newItem2 = new Client(description02);

            //Act
            Client result = Client.Find(2);

            //Assert
            Assert.AreEqual(newItem2, result);
          }


    }

}