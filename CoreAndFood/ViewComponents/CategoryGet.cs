using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace CoreAndFood.ViewComponents
{
    public class CategoryGet : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoriRepository categoriRepository = new CategoriRepository();
            var categoryList = categoriRepository.TList();
            return View(categoryList);
        }
    }
}
