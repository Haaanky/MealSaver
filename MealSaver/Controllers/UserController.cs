using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace MealSaver.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService userService;
        IMemoryCache cache;
        public UserController(UserService userService, IMemoryCache cache)
        {
            this.userService = userService;
            this.cache = cache;
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

            UserLoginVM userLoginVM = userSignUpVM; // Använder en implicit operator i UserLoginVM klassen, motsvarar:
            /*
                UserLoginVM userLoginVM = new UserLoginVM 
                {
                    Username = userSignUpVM.Username,
                    Password = userSignUpVM.Password
                }
             */
            await userService.TryLoginAsync(userLoginVM);
            TempData["Message"] = $"Registeringen lyckades. Välkommen {userSignUpVM.FirstName}!";
            HttpContext.Session.SetString("Name", userSignUpVM.FirstName);
            //cache.Set("supportUserName", userSignUpVM.Username); 

            return Redirect("oversikt");
        }
    }
}