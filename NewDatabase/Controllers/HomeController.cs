using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewDatabase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewDatabase
{
    public class HomeController : Controller
    {
        private Context Context { get; set; }

        public HomeController(Context logger)
        {
            Context = logger;
        }




        public IActionResult Index()
        {
            return View();
        }


        //task form GET
        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categorys = Context.Categorys.ToList();

            return View("AddEdit", new ApplicationResponse());
        }



        //task form post request to add new tasks to the list
        [HttpPost]
        public IActionResult AddEdit(ApplicationResponse mr)
        {
            if (ModelState.IsValid)
            {
                Context.Add(mr);
                Context.SaveChanges();

                return View("Confirmation", mr);
            }
            else //invalid
            {
                ViewBag.Categorys = Context.Categorys.ToList();

                return View(mr);
            }


        }









        public IActionResult Privacy()
        {
            return View();
        }
    }
}
