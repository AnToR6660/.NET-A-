using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class DeliveredController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Delivered
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delivered() 
        {

            var data= db.Approveds.Where(f => f.Food.status == "Delivered").ToList();
            ViewBag.admin = (user)Session["User"];
            return View(Convert(data));
        }


        public static ApprovedDTO Convert(Approved r)
        {
            return new ApprovedDTO
            {
                id = r.id,
                Eid = r.Eid,
                Fid = r.Fid,
                Rid = r.Rid,
                Food = r.Food,
                Restaurant = r.Restaurant,
                Employee = r.Employee,
                deliveredtime = r.deliveredtime,

            };
        }

        public static Approved Convert(ApprovedDTO r)
        {
            return new Approved
            {
                id = r.id,
                Eid = r.Eid,
                Fid = r.Fid,
                Rid = r.Rid,
                Food = r.Food,
                Restaurant = r.Restaurant,
                Employee = r.Employee,
                deliveredtime = r.deliveredtime,




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






    }
}