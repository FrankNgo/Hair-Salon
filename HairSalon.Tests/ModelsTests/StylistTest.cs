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
  }
}
