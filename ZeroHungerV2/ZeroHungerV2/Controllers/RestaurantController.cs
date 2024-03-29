using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class RestaurantController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Restaurant
        public ActionResult Index()
        {
            var data = db.Restaurants.ToList();

            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Restaurant()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Restaurant(RestaurantDTO r)
        {
            var data = Convert(r);
            db.Restaurants.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        [HttpGet]
        public ActionResult Registration() 
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(RestaurantDTO r)
        {
            var data=Convert(r.user);
            data.Uname = r.name;
            db.users.Add(Convert(data));
            db.SaveChanges();

            var data2 = Convert(r);
            db.Restaurants.Add(data2);
            db.SaveChanges();
            return View();
        }




        public static RestaurantDTO Convert(Restaurant r)
        {
            return new RestaurantDTO
            {
               
                name = r.name,
                location = r.location,
            };
        }

        public static Restaurant Convert(RestaurantDTO r)
        {
            ZeroHungerV2Entities db1 = new ZeroHungerV2Entities();
            var user = db1.users.FirstOrDefault(u => u.Uname == r.name && u.pass == r.user.pass);

            return new Restaurant
            {
                uid = user.id,
                name = r.name,
                location = r.location,
            };
        }

        public static List<RestaurantDTO> Convert(List<Restaurant> data)
        {
            var List = new List<RestaurantDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }



        public static userDTO Convert(user r)
        {
            return new userDTO
            {
               Uname=r.Uname,
               pass=r.pass,
               Type=r.Type,
            };
        }

        public static user Convert(userDTO r)
        {
            return new user
            {
                Uname = r.Uname,
                pass = r.pass,
                Type = r.Type,
            };
        }

        public static List<userDTO> Convert(List<user> data)
        {
            var List = new List<userDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }





    }
}