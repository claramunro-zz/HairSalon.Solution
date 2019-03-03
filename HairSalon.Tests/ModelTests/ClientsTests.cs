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

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
      {
        // Arrange
        List<Client> newList = new List<Client> { };

        // Act
        List<Client> result = Client.GetAll();

        // Assert
        CollectionAssert.AreEqual(newList, result);
      }

   
  [TestMethod]
  public void GetAll_ReturnsClients_ClientList()
  {
    //Arrange
    string description01 = "Walk the dog";
    string description02 = "Wash the dishes";
    Client newClient1 = new Client(description01);
    newClient1.Save();
    Client newClient2 = new Client(description02);
    newClient2.Save();
    List<Client> newList = new List<Client> { newClient1, newClient2 };

    //Act
    List<Client> result = Client.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

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




      [TestMethod]
      public void Find_ReturnsCorrectClientFromDatabase_Client()
      {
        //Arrange
        Client testClient = new Client("Mow the lawn");
        testClient.Save();

        //Act
        Client foundClient = Client.Find(testClient.GetId());

        //Assert
        Assert.AreEqual(testClient, foundClient);
      }






    [TestMethod]
      public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Client()
      {
        // Arrange, Act
        Client firstClient = new Client("Mow the lawn");
        Client secondClient = new Client("Mow the lawn");

        // Assert
        Assert.AreEqual(firstClient, secondClient);
      }

      [TestMethod]
      public void Save_SavesToDatabase_ClientList()
      {
        //Arrange
        Client testClient= new Client("Mow the lawn");

        //Act
        testClient.Save();
        List<Client> result = Client.GetAll();
        List<Client> testList = new List<Client>{testClient};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }

      [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
          //Arrange
          Client testClient = new Client("Mow the lawn");

          //Act
          testClient.Save();
          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          //Assert
          Assert.AreEqual(testId, result);
        }


    }

}