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

    [HttpGet("/stylists/{id}")]
    public ActionResult Details(int id)
    {
        Stylist foundStylist = Stylist.Find(id);
        List<Client> clients = foundStylist.GetClients();
        Dictionary<string, object> model = new Dictionary<string,object>();
        model.Add("stylist", foundStylist);
        model.Add("clients", clients);

        return View("Details", model);
    }

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult CreateNewClient(int id)
    {
        Client newClient = new Client(Request.Form["client-first-name"], Request.Form["client-last-name"]);
        newClient.SetStylistId(id);
        newClient.Save();
        return RedirectToAction("Details");
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
