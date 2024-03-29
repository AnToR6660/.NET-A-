using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHungerV2.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {

            // Clear all session data
            Session.Clear();

            // Redirect to the login page or any other page after logout
            return RedirectToAction("Index", "Login");
            
        }
    }
}