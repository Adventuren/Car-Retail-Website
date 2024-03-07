using Business;
using ProjectVB.Areas.Admin.Allowed;
using ProjectVB.Areas.Admin.Extension;
using ProjectVB.Areas.Admin.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Helpers;

namespace ProjectVB.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class AdministratorController : Controller
    {
        private readonly AdminBs _Adminbs;
        private readonly RoleBs _Rolebs;
        private readonly AdminRoleBs _adminRole;
        public  AdministratorController()
        {
            _Adminbs = new AdminBs();
            _Rolebs = new RoleBs();
            _adminRole = new AdminRoleBs();
        }

        [CheckIfAllowed(AllowedRoles = new int[] { 1 })]


      

        public IActionResult Index()
        {
            HomeIndexAH zx = new HomeIndexAH();

            zx.AdminList = _Adminbs.GetAll("AdminRoles", "AdminRoles.Role");
            zx.RoleList = _Rolebs.GetAll();
            return View(zx);
     
        }
        [HttpPost]
        public IActionResult Index(NewAdmin ah)
        {
            try
            {
                Model.Entities.Admin admin = new Model.Entities.Admin();
                AdminRole nRole = new AdminRole();
                admin.FullName = ah.FullName;
                admin.Email = ah.Email;
                admin.Password = ah.Password;
                admin.IsActive = ah.IsActive;

                _Adminbs.Insert(admin);

                for (int i = 0; i < ah.RoleIds.Length; i++)
                {
                    nRole.AdminId = admin.Id;
                    nRole.RoleId = ah.RoleIds[i];
                    nRole.IsActive = true;
                    _adminRole.Insert(nRole);
                }
                return Json(new { Result = true, Message = "Kayit Basarili" });

            }


            catch (Exception)

            {
                return Json(new { Result = false, Message = "Kayit Eklenemedi" });
            }


        }

        public IActionResult Add()
        {
         List<Role> roleList=  _Rolebs.GetAll();

            return View(roleList);
        }

        [HttpPost]
        public IActionResult Add(NewAdmin ah)
        {
            try
            {
                Model.Entities.Admin admin = new Model.Entities.Admin();
                AdminRole nRole = new AdminRole();
                admin.FullName = ah.FullName;
                admin.Email = ah.Email;
                admin.Password = ah.Password;
                admin.IsActive = ah.IsActive;

                _Adminbs.Insert(admin);

                for (int i = 0; i < ah.RoleIds.Length; i++)
                {
                    nRole.AdminId = admin.Id;
                    nRole.RoleId = ah.RoleIds[i];
                    nRole.IsActive = true;
                    _adminRole.Insert(nRole);
                }
                return Json(new { Result = true, Message = "Kayit Basarili" });

            }


            catch (Exception)

            {
                return Json(new { Result = false, Message = "Kayit Eklenemedi" });
            }

            
        }
        [HttpPost]
        public IActionResult UploadPhoto(IFormCollection data)
        {
            IFormFile file = data.Files[0];
            if (file == null)
            {
                return Json(new { result = false, message = "Lütfen fotoğraf seçiniz" });
            }
            if (!file.ContentType.Contains("image/"))
            {
                return Json(new { result = false, message = "Lütfen fotoğraf türünde bir dosya seçiniz" });
            }
            if (file.Length > 300 * 2024) 
            {
                return Json(new { result = false, message = "Yüklediğiniz 300 kb'dan büyük olamaz." });
            }

            string randomFileName = RandomValueGenerator.GenerateFileName(Path.GetExtension(file.FileName));
            string filePath = "/Photos/" + randomFileName;
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + filePath);

            using (FileStream fs = new FileStream(uploadPath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return Json(new { Result = true, photoPath = filePath });
        }
        public IActionResult DeleteAdmin(int adId)
        {
            List<AdminRole> adminRoleList = _adminRole.GetAllAdminById(adId);
            foreach (var item in adminRoleList)
            {
                _adminRole.Delete(item);
            }
            _Adminbs.Delete(adId);

            return Json(new { result = true, message = "Admin Silindi" });
        }

        public IActionResult Forbiden()
        {
            return View();
        }
    }
}
