using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW1.Models;
namespace HW1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MyClass me=new MyClass();
            me.name = "sheikh Tahmeed Hossain";
            me.email = "tahmeedhossain98@gmail.com";
            me.id="20-42981-1";

            ViewBag.me = me;
            return View();
        }

        public ActionResult projects()
        {
           Project oop2 = new Project();
            oop2.ProjectName = "OOP2";
            oop2.ProjectDetails = "Application will allow users to create, update, and delete tasks, as well as mark them as completed. The project will use a console-based user interface.";

            Project oop3 = new Project();
            oop3.ProjectName = "JAVA";
            oop3.ProjectDetails = "Application will allow users to create, update, and delete tasks, as well as mark them as completed. The project will use a console-based user interface.";

            List < Project > projectlist= new List<Project>();
            projectlist.Add(oop2);
            projectlist.Add(oop3);
            
            ViewBag.projectlist = projectlist;
            return View();
        }

        public ActionResult Education()
        {
           MyResult ssc= new MyResult();
            ssc.institution ="MUBC" ;
            ssc.year = 2016;
            ssc.degree = "Ssc";

            MyResult hsc = new MyResult();
            hsc.institution = "BAFSD";
            hsc.year = 2018;
            hsc.degree = "Hsc";

            MyResult Bsc = new MyResult();
            Bsc.institution = "AIUB";
            Bsc.year = 2025;
            Bsc.degree = "BSc";


            ViewBag.education= new[] { ssc, hsc,Bsc };
            return View();
        }

        public ActionResult personal_Details() 
        {
            //ViewBag.Message = "Your personal details";
            PersonalDetails me=new PersonalDetails();
            me.age = "26";
            me.email = "tahmeedhossain89@gmail.com";
            me.phone = "0123456789";
            me.name = "Antor";
            me.position = "Manager";

            ViewBag.details = me;

            return View();
        }
        public ActionResult referance()
        {
            List<Referance> person = new List<Referance>();
            for (int i = 0; i < 4; i++) 
            {
                Referance r1 = new Referance();
                r1.name = "asif hossain "+i;
                r1.email = "asif@gmail.com";
                r1.contact = "40125461265";
                person.Add(r1);
            }

            ViewBag.person = person;

            return View();
        }


    }
}