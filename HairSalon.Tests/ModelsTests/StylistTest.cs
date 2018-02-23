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
     public void GetAll_ListEmpty_0()
     {
       //arrange, act
       int result = Stylist.GetAll().Count;

       //Assert
       Assert.AreEqual(0, result);
     }

     [TestMethod]
     public void Add_AddStylistToList_StylistsList()
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
     public void Add_AddStylistToList_StylistsList()
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

  }
}
