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
            Client newClient = new Client(description);
            newClient.Save();
            List<Client> allClients = Client.GetAll();
            return View("Index", allClients);
        }


        [HttpGet("/clients/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client selectedClient = Client.Find(id);
            List<Stylist> clientStylists = selectedClient.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedClient", selectedClient);
            model.Add("clientStylists", clientStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }


        [HttpPost("/clients/{clientId}/stylists/new")]
        public ActionResult AddStylist(int clientId, int stylistId)
        {
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            client.AddStylist(stylist);
            return RedirectToAction("Show", new { id = clientId });
        }


        [HttpGet("clients/{clientId}/edit")]
        public ActionResult Edit(int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            model.Add("client", client);
            return View(model);
        }


        [HttpPost("/clients/{clientId}")]
        public ActionResult Update(int clientId, string newDescription)
        {
            Client client = Client.Find(clientId);
            client.Edit(newDescription);
            Dictionary<string, object> model = new Dictionary<string, object>();

            List<Stylist> clientStylists = client.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();

            model.Add("selectedClient", client);
            model.Add("clientStylists", clientStylists);
            model.Add("allStylists", allStylists);
            return View("Show", model);
        }


        [HttpGet("/clients/{clientId}/delete")]
        public ActionResult Delete(int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client clientIdD = Client.Find(clientId);
            clientIdD.Delete();
            model.Add("client", clientIdD);
            return View(model);
        }

        [HttpGet("/clients/deleteall")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return View();
        }


    }
}