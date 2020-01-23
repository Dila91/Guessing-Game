using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guessing_Game.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Guessing_Game.Controllers
{
    public class GuessingController : Controller
    {
        //GET - Create a random number every time we refresh the page
        public ActionResult Index()
        {
            //Generate the number ans store it in a session
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            HttpContext.Session.SetInt32("Test Int", number);
            HttpContext.Session.SetInt32("Attempts", 0);

            GuessingViewModel m = new GuessingViewModel();
            return View(m);
        }

        // POST: Check our guess
        [HttpPost]
        public ActionResult Index(GuessingViewModel m)
        {
            int? test = HttpContext.Session.GetInt32("Attempts");
            test++;
            HttpContext.Session.SetInt32("Attempts", (int)test);
            m.CheckTheGuess(m.Guessed, HttpContext.Session.GetInt32("Test Int"), HttpContext.Session.GetInt32("Attempts"));
            return View(m);
        }
    }
}