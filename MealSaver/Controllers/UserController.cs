using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return RedirectToAction(nameof(Overview));

            return Redirect(userLoginVM.ReturnUrl);
        }

        [HttpGet]
        [Route("logga-ut")]
        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
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

            return RedirectToAction(nameof(Login));
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