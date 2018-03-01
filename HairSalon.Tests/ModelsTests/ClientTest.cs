using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=frank_ngo_test;";
    }

    [TestMethod]
    public void GetClientInfo_GetAllClientInfo_String()
    {
      //arrange
      Client newClient = new Client("Joe","Smith");
      string testClientFirstName = "Joe";
      string testClientLastName = "Smith";
      int testId = 0;

      //act
      string clientFirstNameResult = newClient.GetClientFirstName();
      string clientLastNameResult = newClient.GetClientLastName();
      int idResult = newClient.GetClientId();

      //assert
      Assert.AreEqual(clientFirstNameResult,testClientFirstName);
      Assert.AreEqual(clientLastNameResult,testClientLastName);
      Assert.AreEqual(idResult,testId);
    }

    [TestMethod]
    public void GetAll_DatebaseEmptyAtFirst_0()
    {
      //arrange, act
      int result = Client.GetAll().Count;

      //assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CoursesList()
    {
      //arrange
      Client testClient = new Client("Joe", "Smith");

      //act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignedIdToObject_Id()
    {
      //arrange
      Client testClient = new Client("Joe", "Smith");

      //act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetClientId();
      int testId = testClient.GetClientId();

      //assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfAllSame_Course()
    {
      //arrange, act
      Client firsClient = new Client("Joe", "Smith");
      Client secondClient = new Client("Joe", "Smith");

      //assert
      Assert.AreEqual(firsClient, secondClient);
    }
  }
}
