using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/clients")]
        public ActionResult Index()
        {
        List<Client> allClients = Client.GetAll();
        return View(allClients);
        }

    [HttpGet("/clients/new")]
        public ActionResult New()
        {
        return View();
        }
    
    [HttpPost("/clients")]
        public ActionResult Create(string description)
        {
        Client myClient = new Client(description);
        return RedirectToAction("Index");
        }
    
    [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
        Client.ClearAll();
        return View();
        }

      [HttpGet("/clients/{id}")]
        public ActionResult Show(int id)
        {
        Client client = Client.Find(id);
        return View(client);
        }


  }
}