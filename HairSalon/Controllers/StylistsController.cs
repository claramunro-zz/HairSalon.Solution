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
        public ActionResult Create(string name)
        {
            Stylist newStylist = new Stylist(name);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
            // return RedirectToAction("Index");

        }


        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(id);
            List<Specialty> stylistSpecialites = stylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Client> stylistClients = stylist.GetClients();
            List<Client> allClients = Client.GetAll();
            model.Add("stylist", stylist);
            model.Add("stylistSpecialites", stylistSpecialites);
            model.Add("allSpecialties", allSpecialties);
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


        [HttpPost("/stylists/{stylistId}/specialties/new")]
        public ActionResult AddSpecialty(int specialtyId, int stylistId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            Stylist stylist = Stylist.Find(stylistId);
            stylist.AddSpecialty(specialty);
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
            
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            stylist.Edit(newName);
          
            List<Specialty> stylistSpecialites = stylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();

            List<Client> stylistClients = stylist.GetClients();
            List<Client> allClients = Client.GetAll();

            model.Add("stylist", stylist);
            model.Add("stylistSpecialties", stylistSpecialites);
            model.Add("stylistClients", stylistClients);
            model.Add("allClients", allClients);
            model.Add("allSpecialties", allSpecialties);
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