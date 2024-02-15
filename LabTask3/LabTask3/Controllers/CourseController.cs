using LabTask3.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask3.Controllers
{
    public class CourseController : Controller
    {

        [HttpGet]
        public ActionResult courses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult courses(CourseTbl c)
        {
            var db=new labtask3Entities();
            db.CourseTbls.Add(c);
            db.SaveChanges();

            return View(c);
        }

        public ActionResult list() 
        {
            var db=new labtask3Entities();

            var course= (from cs in db.CourseTbls select cs).ToList();

            return View(course);  
        }
    }
}