using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page=1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CatgoryName, Value = x.CatgoryID.ToString() }).ToList();
            ViewBag.vls = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food f)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodAdd");
            }
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.GetT(id);
            List<SelectListItem> values = (from a in c.Categories.ToList() select new SelectListItem { Text = a.CatgoryName, Value = a.CatgoryID.ToString() }).ToList();
            ViewBag.vls = values;
            Food fd = new Food()
            {
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                CategoryID = x.CategoryID,
                ImageUrl = x.ImageUrl,
                FoodID = x.FoodID
            };
            return View(fd);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.GetT(p.FoodID);
            x.Name = p.Name;
            x.Description = p.Description;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.CategoryID = p.CategoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}