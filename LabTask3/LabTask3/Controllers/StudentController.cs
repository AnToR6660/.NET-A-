using LabTask3.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask3.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult students()
        {
            return View();
        }

        [HttpPost]
        public ActionResult students(StudentTbl s)
        {
            var db = new labtask3Entities();
            db.StudentTbls.Add(s);
            db.SaveChanges();

            return View(s);
        }

        public ActionResult list()
        {
            var db = new labtask3Entities();
            var students = (from st in db.StudentTbls select st).ToList();

            return View(students);
        }

    }
}