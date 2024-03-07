using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using ProjectVB.Areas.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Product.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Shop")]
        public IActionResult Index()
        {
            CategoryBs bs = new CategoryBs();
            List<Model.Entities.Category> categoryList = bs.GetAll();

            return View(categoryList);
        }




    }
}
