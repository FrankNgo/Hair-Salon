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

    [HttpGet("/stylists/{id}")]
    public ActionResult Detail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> allClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("clients", allClients);
      return View(model);
    }

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult CreateClient(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist foundStylist = Stylist.Find(id);
        List<Client> stylistClients = foundStylist.GetClients();
        Client newClient = new Client(Request.Form["name"]);
        newClient.SetStylistId(foundStylist.GetId());
        stylistClients.Add(newClient);
        newClient.Add();
        model.Add("clients", stylistClients);
        model.Add("stylist", foundStylist);
        return View("Detail", model);
    }
  }
}
