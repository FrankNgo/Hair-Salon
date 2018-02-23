using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      // Client.DeleteAll();
      // Stylist.DeleteAll();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=frank_ngo_test;";
    }

    [TestMethod]
    public void GetclientName_UserInputForClientName_String()
    {
      //arrange
      Client newCLient = new Client("Jim Harper");
      string testClientName = "Jim Harper";

      //act
      string result = newCLient.GetClientName();

      //assert
      Assert.AreEqual(result, testClientName);
    }
  }
}
