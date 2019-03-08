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
            List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedSpecialty", selectedSpecialty);
            model.Add("specialtyStylists", specialtyStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }


        [HttpPost("/specialties/{specialtyId}/stylists/new")]
        public ActionResult AddStylist(int specialtyId, int stylistId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            Stylist stylist = Stylist.Find(stylistId);
            specialty.AddStylist(stylist);
            return RedirectToAction("Show", new { id = specialtyId });
        }


        [HttpGet("specialties/{specialtyId}/edit")]
        public ActionResult Edit(int specialtyId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty specialty = Specialty.Find(specialtyId);
            model.Add("specialty", specialty);
            return View(model);
        }


        [HttpPost("/specialties/{specialtyId}")]
        public ActionResult Update(int specialtyId, string newStyle)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            specialty.Edit(newStyle);
            Dictionary<string, object> model = new Dictionary<string, object>();

            List<Stylist> specialtyStylists = specialty.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();

            model.Add("selectedSpecialty", specialty);
            model.Add("specialtyStylists", specialtyStylists);
            model.Add("allStylists", allStylists);
            return View("Show", model);
        }


        [HttpGet("/specialties/{specialtyId}/delete")]
        public ActionResult Delete(int specialtyId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty specialtyIdD = Specialty.Find(specialtyId);
            specialtyIdD.Delete();
            model.Add("specialty", specialtyIdD);
            return View(model);
        }


        [HttpGet("/specialties/deleteall")]
        public ActionResult DeleteAll()
        {
            Specialty.ClearAll();
            return View();
        }


    }
}