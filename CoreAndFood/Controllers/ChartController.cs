using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(FoodList());
        }
        public List<Class1> FoodList()
        {
            List<Class1> cs = new List<Class1>();
            using (var c = new Context())
            {
                cs = c.Foods.Select(x => new Class1
                {

                    FoodName = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs;
        }
        public IActionResult Statick()
        {
            Context c = new Context();
            var deger1 = c.Foods.Count();
            var deger2 = c.Categories.Count();
            var foid = c.Categories.Where(x => x.CatgoryName == "Fruit").Select(y => y.CatgoryID).FirstOrDefault();
            var deger3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            var deger4 = c.Foods.Where(x => x.CategoryID == (c.Categories.Where(z =>z.CatgoryName == "Vegetables").Select(y => y.CatgoryID).FirstOrDefault())).Count();
            var deger5 = c.Foods.Sum(x => x.Stock);
            var deger6 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            var deger7 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            var deger8 = c.Foods.Average(x => x.Price).ToString("0.00"); 
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            return View();
        }
    }
}