using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoriRepository categoriRepository = new CategoriRepository();
        public IActionResult Index()
        {
          
            return View(categoriRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
       [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoriRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoriRepository.GetT(id);
            Category ct = new Category()
            {
                CatgoryName = x.CatgoryName,
                CatgoryDescription = x.CatgoryDescription,
                CatgoryID = x.CatgoryID
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoriRepository.GetT(p.CatgoryID);
            x.CatgoryName = p.CatgoryName;
            x.CatgoryDescription = p.CatgoryDescription;
            x.Status = p.Status;
            categoriRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoriRepository.GetT(id);
            x.Status = false;
            categoriRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}