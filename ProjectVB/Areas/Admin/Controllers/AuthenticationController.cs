using Business;
using ProjectVB.Areas.Admin.Extension;
using ProjectVB.Areas.Admin.Models;
using Infrastructure;
using Infrastructure.Helpers;
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
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LogIn(LoginViewModel jsonData)
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("LoggedAdmin");
            AdminBs bs = new AdminBs();
            Model.Entities.Admin admin = bs.LogIn(jsonData.Email, jsonData.Password,"AdminRoles");
            if(admin!=null)
            {
                HttpContext.Session.SetObject("LoggedAdmin", admin);




                return Json(new { result = true });
            }

            return Json(new {result=false, Message = "Basarisiz", AlertStyle = "danger" });
        }

        [HttpPost]
        public IActionResult SendPassword(ForgetPassword rx)
        {
            
                AdminBs bs = new AdminBs();
            Model.Entities.Admin admin = bs.GetByEmail(rx.Email);
            if (admin != null)
            {
                admin.Password = RandomValueGenerator.GeneratePassword();
                bs.Update(admin);
                return Json(new { result = true, message = "Sifreniz mail adresinize gonderilmistir." });
                string message = $"Sayın {admin.FullName}. Yeni Şifreniz: <b>" + admin.Password + "</b>}";

                MailHelper.SendMail(rx.Email, "Yeni Sifreniz", message);
                return Json(new { result = true, message = "şifreniz mail adresinize gönderilmiştir." });
            }
            else
                return Json(new { result = false, message = "Bu mail adresinin kayiti bulunmamistir" });

            
        }


           
        
    }
}
