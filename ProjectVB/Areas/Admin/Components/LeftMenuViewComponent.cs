using Microsoft.AspNetCore.Mvc;
using ProjectVB.Areas.Admin.Extension;

namespace ProjectVB.Areas.Admin.Components
{

    public class LeftMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Model.Entities.Admin admin = HttpContext.Session.GetObject<Model.Entities.Admin>("LoggedAdmin");

            ViewBag.LoggedAdmin = admin;
            return View();
        }
    }
}
