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
      List<Client> allItems = Client.GetAll();
      return View(allItems);
    }


    [HttpGet("/clients/new")]
    public ActionResult New()
    {
      return View();
    }

    
    [HttpPost("/clients")]
    public ActionResult Create(string description)
    {
      Client newItem = new Client(description);
      newItem.Save();
      List<Client> allItems = Client.GetAll();
      return View("Index", allItems);
    }


    // [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    //     public ActionResult Show(int stylistId, int clientId)
    //     {
    //     Client client = Client.Find(clientId);
    //     Dictionary<string, object> model = new Dictionary<string, object>();
    //     Stylist stylist = Stylist.Find(stylistId);
    //     model.Add("client", client);
    //     model.Add("stylist", stylist);
    //     return View(model);
    //     }


    //   [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
    //     public ActionResult Edit(int stylistId, int clientId)
    //     {
    //       Dictionary<string, object> model = new Dictionary<string, object>();
    //       Stylist stylist = Stylist.Find(stylistId);
    //       model.Add("stylist", stylist);
    //       Client client = Client.Find(clientId);
    //       model.Add("client", client);
    //       return View(model);
    //     }


    //     [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
    //     public ActionResult Update(int stylistId, int clientId, string newDescription)
    //     {
    //       Client client = Client.Find(clientId);
    //       client.Edit(newDescription);
    //       Dictionary<string, object> model = new Dictionary<string, object>();
    //       Stylist stylist = Stylist.Find(stylistId);
    //       model.Add("stylist", stylist);
    //       model.Add("client", client);
    //       return View("Show", model);
    //     }


      // [HttpPost("/clients/delete")]
      //         public ActionResult DeleteAll()
      //         {
      //         Client.ClearAll();
      //         return View();
      //         }


  }
}