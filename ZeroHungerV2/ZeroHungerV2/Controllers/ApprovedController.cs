using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class ApprovedController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Approved
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Approved()
        {

            var foods = db.Foods.Where(f => f.status =="Permitted" ).ToList();
            ViewBag.Foods = foods;

            var employees = db.Employees.Where(f => f.status == "free").ToList();
            ViewBag.Employees = employees;

            ViewBag.admin = (user)Session["User"];

            return View();
        }


        [HttpPost]
        public ActionResult Approved(ApprovedDTO a)
        {
            var data = Convert(a);
            db.Approveds.Add(data);
            db.SaveChanges();

            var food = (from u in db.Foods
                        where u.id.Equals(a.Fid)
                        select u).SingleOrDefault();
            food.status = a.Food.status;
            db.SaveChanges();

            return RedirectToAction("Approved");
        }

        public static ApprovedDTO Convert(Approved r)
        {
            return new ApprovedDTO
            {
                id = r.id,
                Eid = r.Eid,
                Fid = r.Fid,
                Rid = r.Rid,
                Employee = r.Employee,
                Food = r.Food,
                Restaurant = r.Restaurant,
                deliveredtime=r.deliveredtime,

            };
        }

        public static Approved Convert(ApprovedDTO r)
        {
            return new Approved
            {
                Eid=r.Eid,
                Fid=r.Fid,
                Rid=r.Rid,
                


            };
        }

        public static List<ApprovedDTO> Convert(List<Approved> data)
        {
            var List = new List<ApprovedDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }

        public ActionResult AssignedEmployee() 
        {
            
            var filteredData = db.Approveds.Where(f => f.Food.status == "OnDelivery").ToList();
            return View(Convert(filteredData));
              
        }


        



    }
}