using LabTask3.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask3.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        [HttpGet]
        public ActionResult departments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult departments(DepartmentTbl d)
        {
            var db = new labtask3Entities();
            db.DepartmentTbls.Add(d);
            db.SaveChanges();

            return View(d);
        }

        public ActionResult list() 
        {
            var db = new labtask3Entities();

            var department=(from dp in db.DepartmentTbls select dp).ToList();

            return View(department);
        }

    }
}