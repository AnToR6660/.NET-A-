using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class AdminController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Food
        public ActionResult Index()
        {
            var data = db.Foods.Where(f => f.status == "OnDelivery").ToList();
            ViewBag.admin = (user)Session["User"];
            return View(Convert(data));
        }



        [HttpGet]
        public ActionResult Food()
        {

            var food = db.Foods.Where(f => f.status == "Assigned").ToList();
            ViewBag.foods = Convert(food);
            ViewBag.admin = (user)Session["User"];
            return View();
        }




        [HttpPost]
        public ActionResult Food(FoodDTO f)
        {
            var data = Convert(f);

            var food = (from u in db.Foods
                        where u.id.Equals(data.id)
                        select u).SingleOrDefault();
            food.status = data.status;
            db.SaveChanges();


            return RedirectToAction("Food");
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
                status = "Permitted",
                assigntime =r.assigntime,




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