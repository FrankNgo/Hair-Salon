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
      // Student.DeleteAll();
      // Course.DeleteAll();
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
  }
}
