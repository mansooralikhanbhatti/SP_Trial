﻿using Microsoft.AspNetCore.Mvc;
using SP_Trial.Entities;
using SP_Trial.Models;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace SP_Trial.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult SubmitLogin(LoginModel loginmodel)
        {
            var dbcontext = new ShoppingKartDBContext();
            Entities.User userObj = dbcontext.Users.FirstOrDefault(p => p.UserName == loginmodel.UserName && p.Password == loginmodel.Password);
            if (userObj == null)
            {
                ModelState.AddModelError("", "Entered username or password is incorrect.");
                return View("Login", loginmodel);
            }
            else
            {
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public IActionResult RegisterForm()
        {
            var model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveUser(RegisterModel registerModel)
        {
            var dbcontext = new ShoppingKartDBContext();
            Entities.User NewUser = new Entities.User();
            NewUser.UserName = registerModel.UserName;
            NewUser.Password = registerModel.Password;
            NewUser.Email = registerModel.Email;

            dbcontext.Users.Add(NewUser);
            dbcontext.SaveChanges();

            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}