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
            var db = new labtask3Entities();
            db.CourseTbls.Add(c);
            db.SaveChanges();

            return View(c);
        }

        public ActionResult list()
        {
            var db = new labtask3Entities();

            var course = (from cs in db.CourseTbls select cs).ToList();

            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new labtask3Entities();
            var course = db.CourseTbls.Find(id);

            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(CourseTbl newc)
        {
            var db = new labtask3Entities();
            var newcourse = db.CourseTbls.Find(newc.id);
            newcourse.name = newc.name;
            newcourse.courseId = newc.courseId;
            newcourse.credit = newc.credit;
            db.SaveChanges();

            return RedirectToAction("list");

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new labtask3Entities();
            var data = db.CourseTbls.Find(id);

            return View(data);

        }

        [HttpPost]
        public ActionResult Delete(CourseTbl c) 
        {
            var db = new labtask3Entities();
            var course = db.CourseTbls.Find(c.id);
            db.CourseTbls.Remove(course);
            db.SaveChanges();
            return RedirectToAction("list");
        }

    }
}