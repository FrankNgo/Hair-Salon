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
    public void GetStylistsInfo_FetchAllInfo_String()
    {
      //arrange
      Stylist newStylist = new Stylist("Frank","Ngo");
      string testFirstName = "Frank";
      string testLastName = "Ngo";
      int testId = 0;

      //act
      string firstNameResult = newStylist.GetFirstName();
      string lastNameResult = newStylist.GetLastName();
      int idResult = newStylist.GetId();

      //assert
      Assert.AreEqual(firstNameResult,testFirstName);
      Assert.AreEqual(lastNameResult,testLastName);
      Assert.AreEqual(idResult,testId);
    }

    [TestMethod]
    public void GetAll_DatebaseEmptyAtFirst_0()
    {
      //arrange, act
      int result = Stylist.GetAll().Count;

      //assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      //arrange
      Stylist testStylist = new Stylist("Frank","Ngo");

      //act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
