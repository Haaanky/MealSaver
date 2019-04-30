using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealSaver.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("logga-in")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Route("logga-in")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (!ModelState.IsValid)
                return View(userLoginVM);

            var result = await userService.TryLoginAsync(userLoginVM);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(UserLoginVM.Username), "Login failed");
                return View(userLoginVM);
            }
            if (string.IsNullOrWhiteSpace(userLoginVM.ReturnUrl))
                return Redirect("oversikt");

            return Redirect(userLoginVM.ReturnUrl);
        }

        [HttpGet]
        [Route("logga-ut")]
        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
            return Redirect("/");
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
        public async Task<IActionResult> SignUp(UserSignUpVM userSignUpVM)
        {
            if (!ModelState.IsValid)
                return View(userSignUpVM);

            var result = await userService.TryRegisterAsync(userSignUpVM);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                return View(userSignUpVM);
            }

            //return RedirectToAction(nameof(Login)); // Ändra så att man blir inloggad direkt och hamnar på overview

            UserLoginVM userLoginVM = userSignUpVM;
            await userService.TryLoginAsync(userLoginVM);
            return Redirect("oversikt");
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
            var viewModel = new UserAddItemVM
            {
                //lägg till fler alternativ
                FoodItem = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Välj", Selected = true},
                    new SelectListItem {Value = "2", Text = "Mjölk"},
                    new SelectListItem {Value = "3", Text = "Kött"},
                    new SelectListItem {Value = "4", Text = "Frukt"}
                },

                ItemWeight = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Välj", Selected = true},
                    new SelectListItem {Value = "2", Text = "Kg"},
                    new SelectListItem {Value = "3", Text = "g"},
                    new SelectListItem {Value = "4", Text = "L"},
                    new SelectListItem {Value = "5", Text = "dl"}
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("lagga-till")]
        public IActionResult AddItem(UserAddItemVM userAddItemVM)
        {
            return RedirectToAction(nameof(AddItem));
        }
    }
}