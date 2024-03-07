using Business;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Entities;
namespace ProjectVB.Areas.Shop.Controllers
{
    public class ProductController : Controller
    {
        [Area("Shop")]
        public IActionResult ProductList(int id)
        {
            ProductBs bs = new ProductBs();


            IEnumerable<Model.Entities.Product> productList = bs.GetAll().Where(x => x.CategoryId == id).ToList();


            return View(productList);
        }
    }
}
