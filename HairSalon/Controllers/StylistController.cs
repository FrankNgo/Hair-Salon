using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateStylistForm()
    {
      return View("CreateStylistForm");
    }

    [HttpPost("/stylists")]
    public ActionResult CreateStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["first-name"],Request.Form["last-name"]);
      newStylist.Save();

      return RedirectToAction("Index", "stylists");
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist foundStylist = Stylist.Find(id);
      foundStylist.Delete();
      return RedirectToAction("Index","stylist");
    }
  }
}
