using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {


        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }


        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }


        [HttpPost("/stylists")]
        public ActionResult Create(string stylistName)
        {
            Stylist newStylist = new Stylist(stylistName);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }


        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            List<Client> allClients = Client.GetAll();
            model.Add("selectedStylist", selectedStylist);
            model.Add("stylistClients", stylistClients);
            model.Add("allClients", allClients);
            return View(model);
        }


        [HttpPost("/stylists/{stylistId}/clients/new")]
        public ActionResult AddClient(int stylistId, int clientId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(clientId);
            stylist.AddClient(client);
            return RedirectToAction("Show", new { id = stylistId });
        }


        [HttpGet("/stylists/{stylistId}/edit")]
        public ActionResult Edit(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            return View(model);
        }


        [HttpPost("/stylists/{stylistId}")]
        public ActionResult Update(int stylistId, string newName)
        {
            Stylist stylist = Stylist.Find(stylistId);
            stylist.Edit(newName);
            Dictionary<string, object> model = new Dictionary<string, object>();

            List<Client> stylistClients = stylist.GetClients();
            List<Client> allClients = Client.GetAll();

            model.Add("selectedStylist", stylist);
            model.Add("stylistClients", stylistClients);
            model.Add("allClients", allClients);
            return View("Show", model);
        }


        [HttpGet("/stylists/{stylistId}/delete")]
        public ActionResult Delete(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylistIdD = Stylist.Find(stylistId);
            stylistIdD.Delete();
            model.Add("stylist", stylistIdD);
            return View(model);
        }


        [HttpGet("/stylists/deleteall")]
        public ActionResult DeleteAll()
        {
            Stylist.ClearAll();
            return View();
        }




    }
}