using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;
using MySql.Data.MySqlClient;


namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

      public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=clara_munro_test;";
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

    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_ClientList()
    //   {
    //     // Arrange
    //     List<Client> newList = new List<Client> { };

    //     // Act
    //     List<Client> result = Client.GetAll();

    //     // Assert
    //     CollectionAssert.AreEqual(newList, result);
    //   }

    // [TestMethod]
    // public void GetAll_ReturnsClients_ClientList()
    //   {
    //     //Arrange
    //     string description01 = "Zoey";
    //     string description02 = "Clara";
    //     Client newClient1 = new Client(description01);
    //     Client newClient2 = new Client(description02);
    //     List<Client> newList = new List<Client> { newClient1, newClient2 };

    //     //Act
    //     List<Client> result = Client.GetAll();

    //     //Assert
    //     CollectionAssert.AreEqual(newList, result);
    //   }

    //   [TestMethod]
    //   public void GetId_ClientsInstantiateWithAnIdAndGetterReturns_Int()
    //     {
    //       //Arrange
    //       string description = "Walk the dog.";
    //       Client newClient = new Client(description);

    //       //Act
    //       int result = newClient.GetId();

    //       //Assert
    //       Assert.AreEqual(1, result);
    //     }

    //     [TestMethod]
    //     public void Find_ReturnsCorrectClient_Client()
    //       {
    //         //Arrange
    //         string description01 = "Walk the dog";
    //         string description02 = "Wash the dishes";
    //         Client newClient1 = new Client(description01);
    //         Client newClient2 = new Client(description02);

    //         //Act
    //         Client result = Client.Find(2);

    //         //Assert
    //         Assert.AreEqual(newClient2, result);
    //       }


    }

}