using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      // Client.DeleteAll();
      // Stylist.DeleteAll();
    }
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=frank_ngo_test;";
    }
    [TestMethod]
    public void GetAll_StylistList_empty()
    {
      //arrange, act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrue_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Frank Ngo");
      Stylist secondStylist = new Stylist("Frank Ngo");

      //assert
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Add_SavesStylistToList_StylistList()
    {
      //arrange
      Stylist testStylist = new Stylist("Frank Ngo");
      testStylist.Add();

      //act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Add_SavesIdToStylist_StylistId()
    {
      //arrange
      Stylist testStylist = new Stylist("Frank Ngo");
      testStylist.Add();

      //act
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylistId_ClientList()
    {
      Stylist testStylist = new Stylist("Frank Ngo", 1);
      testStylist.Add();

      Client firstClient = new Client("Frank Ngo", 1, testStylist.GetId());
      firstClient.Add();
      Client secondClient = new Client("Frank Ngo", 2,  testStylist.GetId());
      secondClient.Add();

      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      CollectionAssert.AreEqual(testClientList, resultClientList);
    }
  }
}
