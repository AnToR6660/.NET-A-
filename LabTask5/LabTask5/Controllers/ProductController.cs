using LabTask5.DTOs;
using LabTask5.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask5.Controllers
{
    public class ProductController : Controller
    {
        ShoppingDBEntities db=new ShoppingDBEntities();
        // GET: Product
        public ActionResult Index()
        {
            var data=db.ProductTbls.ToList();
            return View(Convert(data));
            
        }

        [HttpGet]
        public ActionResult Create() 
        {
            var data=db.Categories.ToList();
            ViewBag.Category = CategoryController.Convert(data);
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductDTO p) 
        {
            var data = Convert(p);
            db.ProductTbls.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }


        public static ProductDTO Convert(ProductTbl p) 
        {
            return new ProductDTO
            {
                Id = p.Id,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Quantity = p.Quantity,
                Category=p.Category,
            };

        }

        public static ProductTbl Convert(ProductDTO p)
        {
            return new ProductTbl
            {
                Id = p.Id,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Quantity = p.Quantity,
            };

        }

        public static List<ProductDTO> Convert(List<ProductTbl> data) 
        {
            var list = new List<ProductDTO>();
            foreach (var item in data) 
            {
                list.Add(Convert(item));
            }
            return list;

        }

    }
}