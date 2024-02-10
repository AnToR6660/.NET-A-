using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormDataRetrive.Models;

namespace FormDataRetrive.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid) 
            {
                return RedirectToAction("welcome");
            }
            return View(s);
        }

        public ActionResult welcome ()
        {
            return View();
        }




    }
}