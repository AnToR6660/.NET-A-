using LabTask5.DTOs;
using LabTask5.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask5.Controllers
{
    public class OrderController : Controller
    {
        ShoppingDBEntities db = new ShoppingDBEntities();
        // GET: Order
        public ActionResult Index()
        {
            var data=db.ProductTbls.ToList();

            return View(ProductController.Convert(data));
        }

        [HttpGet]
        public ActionResult AddToCart() 
        {
            var product=db.ProductTbls.ToList();
            ViewBag.Product=ProductController.Convert(product);
            
            return View();
        }



        [HttpPost]
        public ActionResult AddToCart(ProductDTO p) 
        {
            var product=db.ProductTbls.Find(p.Id);
            var data=ProductController.Convert(product);
            data.Quantity = p.Quantity;
            List<ProductDTO> products = null;

            if (Session["cart"] == null)
            {
                products = new List<ProductDTO>();
            }
            else 
            {
                products = (List<ProductDTO>)Session["cart"];
            }
            products.Add(data);
            Session["cart"]=products;
            return RedirectToAction("Index");
        }

        public ActionResult Cart() 
        {
            if (Session["cart"] == null)
            {
                return View();

            }
            else 
            {
                var products = (List<ProductDTO>)Session["cart"];
                return View(products);
            }
            
        }

    }
}