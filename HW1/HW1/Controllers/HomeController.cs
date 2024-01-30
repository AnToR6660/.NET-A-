using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult projects()
        {
           // ViewBag.Message = "Your project's page.";

            return View();
        }

        public ActionResult Education()
        {
           // ViewBag.Message = "Your educational details";

            return View();
        }

        public ActionResult personal_Details() 
        {
            //ViewBag.Message = "Your personal details";
            return View();
        }
        public ActionResult referance()
        {
           // ViewBag.Message = "Your referances";
            return View();
        }


    }
}