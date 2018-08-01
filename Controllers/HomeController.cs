using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostandFoundAnimals.Models;

namespace LostandFoundAnimals.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult Welcome(){
            return View();
        }
        public IActionResult About(string searchString)
        {
            ViewData["Message"] = searchString;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "A contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
