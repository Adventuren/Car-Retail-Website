using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
