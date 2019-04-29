using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("logga-in")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("logga-in")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginVM userLoginVM)
        {
            return RedirectToAction(nameof(Overview));
        }
        [HttpGet]
        [Route("logga-ut")]
        public IActionResult Logout()
        {
            return Redirect("");
        }
        [HttpGet]
        [Route("registrera")]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("registrera")]
        [AllowAnonymous]
        public IActionResult SignUp(UserSignUpVM userSignUpVM)
        {
            return View(userSignUpVM);
        }
        [HttpGet]
        [Route("oversikt")]
        public IActionResult Overview()
        {
            return View();
        }
        [HttpGet]
        [Route("lagga-till")]
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        [Route("lagga-till")]
        public IActionResult AddItem(UserAddItemVM userAddItemVM)
        {
            return RedirectToAction(nameof(AddItem));
        }
    }
}