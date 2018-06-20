using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_ASP_NET_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_ASP_NET_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        // Home page which will display form for user to input years to parse "Person of the Year" by
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Page to send years input by the user back to the Controller for processing
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        // Page to display the "Person of the year", sorted to only include user specified years
        public IActionResult Results(int startYear, int endYear)
        {
            // logic to send data to View

            PersonsOfTheYear person = new PersonsOfTheYear();

            return View(person.GetPersons(startYear, endYear));
        }
    }
}
