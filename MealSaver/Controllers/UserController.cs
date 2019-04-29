using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserSignUpVM userSignUpVM)
        {
            return View(userSignUpVM);
        }
        public IActionResult Overview()
        {
            return View();
        }
        public IActionResult AddItem()
        {
            return View();
        }
    }
}