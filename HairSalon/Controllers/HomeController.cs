using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
        public ActionResult Index()
        {
        Client starterItem = new Client("Add first item to To Do List");
        return View(starterItem);
        }
    


  }
}