using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectVB.Areas.Admin.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Admin.Allowed
{
    public class CheckIfAllowed:ActionFilterAttribute
    {
        public int [] AllowedRoles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Model.Entities.Admin admin = context.HttpContext.Session.GetObject<Model.Entities.Admin>("LoggedAdmin");
            foreach (var role in admin.AdminRoles)
            {
                foreach (var allowedRoleId in AllowedRoles)
                {
                    if(allowedRoleId==role.Id)
                    {
                        return;
                    }
                }
            }
            context.Result = new RedirectToActionResult("Forbiden", "Administrator", null);
        }
    }
}
