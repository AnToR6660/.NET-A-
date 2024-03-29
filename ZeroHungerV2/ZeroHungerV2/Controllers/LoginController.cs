using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.DTOs;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class LoginController : Controller
    {
        ZeroHungerV2Entities db = new ZeroHungerV2Entities();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Index(LoginDTO l) 
        {
           
                var user = (from u in db.users
                            where u.Uname.Equals(l.Uname)
                            && u.pass.Equals(l.pass)
                            select u).SingleOrDefault();

                if (user != null)
                {

                    if (user.Type.Equals("admin"))
                    {
                        Session["User"] = user;
                        return RedirectToAction("Food", "Admin");
                    }
                    if (user.Type.Equals("restaurant"))
                    {
                        var restaurant = (from u in db.Restaurants
                                          where u.uid.Equals(user.id)
                                          select u).SingleOrDefault();
                        Session["restaurant"] = restaurant;
                        Session["User"] = user;
                        return RedirectToAction("Food", "Food");
                    }
                    if (user.Type.Equals("employee"))
                    {
                        Session["User"] = user;
                        return RedirectToAction("EmployeeFood", "Employee");

                    }
                }

            
            return RedirectToAction("Index");

        }
    }
}