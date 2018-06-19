using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //[HttpPost]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // Page to display the "Person of the year", sorted to only include user specified years
        public IActionResult Results()
        {
            return View();
        }
    }
}
