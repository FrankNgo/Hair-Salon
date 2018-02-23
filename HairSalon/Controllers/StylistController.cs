using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;


namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
      List<Stylist> allStylist = Stylist.GetAll();
      return View("Index", allStylist);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult CreateStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["name"]);
      newStylist.Add();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult DeleteStylist(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Delete();
      return RedirectToAction("Index");
    }

  }
}
