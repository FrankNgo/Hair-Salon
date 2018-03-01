using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest
  {
    [TestMethod]
    public void Index_ReturnIfTrue_View()
    {
      //arrange
      StylistController controller = new StylistController();

      //act
      IActionResult indexView = controller.Index();
      ViewResult result = indexView as ViewResult;

      //assert
      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModelType_True()
    {
      //arrange
      ViewResult indexView = new StylistController().Index() as ViewResult;

      //act
      var result = indexView.ViewData.Model;

      //assert
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }
  }
}
