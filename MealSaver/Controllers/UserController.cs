using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [AllowAnonymous] //ta bort när vi är klara
        public IActionResult Overview()
        {
            return View();
        }
        [HttpGet]
        [Route("lagga-till")]
        [AllowAnonymous] //ta bort när vi är klara
        public IActionResult AddItem()
        {
            var viewModel = new UserAddItemVM
            {
                FoodArray = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Välj", Selected = true},
                    new SelectListItem {Value = "2", Text = "Mjölk"},
                    new SelectListItem {Value = "3", Text = "Kött"},
                    new SelectListItem {Value = "4", Text = "Frukt"}
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("lagga-till")]
        [AllowAnonymous] //ta bort när vi är klara
        public IActionResult AddItem(UserAddItemVM userAddItemVM)
        {
            return RedirectToAction(nameof(AddItem));
        }
    }
}