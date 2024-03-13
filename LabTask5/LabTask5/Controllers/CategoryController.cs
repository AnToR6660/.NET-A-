using LabTask5.DTOs;
using LabTask5.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask5.Controllers
{
    public class CategoryController : Controller
    {
        ShoppingDBEntities db=new ShoppingDBEntities();
        // GET: Category
        public ActionResult Index()
        {
            var data=db.Categories.ToList();
            return View(Convert(data));
            
        }

        [HttpGet]
        public ActionResult create() 
        {

            return View();
        }

        [HttpPost]
        public ActionResult create(CategoryDTO c) 
        {
            var data=Convert(c);
            db.Categories.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
            

            
        }


        public static CategoryDTO Convert(Category c) 
        {
            return new CategoryDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
            };
        }

        public static Category Convert(CategoryDTO c) 
        {
            return new Category 
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
            };
        }

        public static List<CategoryDTO> Convert(List<Category> data) 
        {
            var List=new List<CategoryDTO>();
            foreach (var item in data) 
            {
                List.Add(Convert(item));
            }
            return List;

        }


    }
}