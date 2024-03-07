using ProjectVB.Areas.Admin.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            Model.Entities.Admin admin = HttpContext.Session.GetObject<Model.Entities.Admin>("LoggedAdmin");

            ViewBag.AdminFullName = admin.FullName;
            return View();
        }
    }
}
