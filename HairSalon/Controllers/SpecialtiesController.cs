using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {

        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }


        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }


        [HttpPost("/specialties")]
        public ActionResult Create(string style)
        {
            Specialty newSpecialty = new Specialty(style);
            newSpecialty.Save();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }


        [HttpGet("/specialties/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty selectedSpecialty = Specialty.Find(id);
            List<Stylist> specialtyStylists = selectedSpecialty.GetSpecialties();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedSpecialty", selectedSpecialty);
            model.Add("specialtyStylists", specialtyStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }


        // [HttpPost("/clients/{clientId}/stylists/new")]
        // public ActionResult AddStylist(int clientId, int stylistId)
        // {
        //     Client client = Client.Find(clientId);
        //     Stylist stylist = Stylist.Find(stylistId);
        //     client.AddStylist(stylist);
        //     return RedirectToAction("Show", new { id = clientId });
        // }


        // [HttpGet("clients/{clientId}/edit")]
        // public ActionResult Edit(int clientId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Client client = Client.Find(clientId);
        //     model.Add("client", client);
        //     return View(model);
        // }


        // [HttpPost("/clients/{clientId}")]
        // public ActionResult Update(int clientId, string newDescription)
        // {
        //     Client client = Client.Find(clientId);
        //     client.Edit(newDescription);
        //     Dictionary<string, object> model = new Dictionary<string, object>();

        //     List<Stylist> clientStylists = client.GetStylists();
        //     List<Stylist> allStylists = Stylist.GetAll();

        //     model.Add("selectedClient", client);
        //     model.Add("clientStylists", clientStylists);
        //     model.Add("allStylists", allStylists);
        //     return View("Show", model);
        // }


        // [HttpGet("/clients/{clientId}/delete")]
        // public ActionResult Delete(int clientId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Client clientIdD = Client.Find(clientId);
        //     clientIdD.Delete();
        //     model.Add("client", clientIdD);
        //     return View(model);
        // }

        // [HttpGet("/clients/deleteall")]
        // public ActionResult DeleteAll()
        // {
        //     Client.ClearAll();
        //     return View();
        // }


    }
}