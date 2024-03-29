using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class FoodController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Food
        public ActionResult Index()
        {
            var data =(user) Session["User"];
            var filteredData = db.Foods.Where(f => f.uid == data.id).ToList();
            ViewBag.data2 = (Restaurant)Session["restaurant"];
            return View(Convert(filteredData));
        }

        [HttpGet]
        public ActionResult Food()
        {
            ViewBag.data = (user)Session["User"];
            ViewBag.data2=(Restaurant) Session["restaurant"];
            
            return View();
        }

        [HttpPost]
        public ActionResult Food(FoodDTO f)
        {
            var data = Convert(f);
            db.Foods.Add(data);
            db.SaveChanges();


            return RedirectToAction("Index");
        }



        public static FoodDTO Convert(Food r)
        {
            return new FoodDTO
            {
                id = r.id,
                name = r.name,
                quantity = r.quantity,
                time = r.time,
                Rid = r.Rid,
                uid = r.uid,
                status = r.status,
                assigntime = r.assigntime,
                Restaurant = r.Restaurant,

            };
        }

        public static Food Convert(FoodDTO r)
        {
            return new Food
            {
                id = r.id,
                name = r.name,
                quantity = r.quantity,
                time = r.time,
                Rid = r.Rid,
                uid = r.uid,
                status = "Assigned",
                assigntime=DateTime.Now,


            };
        }

        public static List<FoodDTO> Convert(List<Food> data)
        {
            var List = new List<FoodDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }
    }
}