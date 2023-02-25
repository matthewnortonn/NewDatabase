using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        //vew for the quadrant page
        [HttpGet]
        public IActionResult Quadrant()
        {
            var applications = Context.Responses.Include(x => x.Category).ToList();
            ViewBag.Categorys = Context.Categorys.ToList();
            return View("Quadrant", applications);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Categorys = Context.Categorys.ToList();

            var application = Context.Responses.Single(x => x.TaskId == id);
            return View("AddEdit", application);
        }
        //task form post request to add new tasks to the list
        [HttpPost]
        public IActionResult Edit(ApplicationResponse mr)
        {

            if (ModelState.IsValid)
            {
                Context.Update(mr);
                Context.SaveChanges();
                return RedirectToAction("Quadrant");
            }
            else
            {
                return View(mr);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = Context.Responses.Single(x => x.TaskId == id);
            Context.Responses.Remove(application);
            Context.SaveChanges();

            return RedirectToAction("Quadrant");
        }
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
