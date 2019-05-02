using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService userService;

        public HomeController(UserService userService)
        {
            this.userService = userService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Inspiration")]
        public IActionResult Inspiration()
        {
            return PartialView("_PartialInspiration");
        }
        [Route("HurDetFungerar")]
        public IActionResult PartialHowItWorks()
        {
            return PartialView("_PartialHowItWorks");
        }
        [Route("VarforMealsaver")]
        public IActionResult PartialWhyUseWasteland()
        {
            return PartialView("_PartialWhyUseWasteland");
        }
        public IActionResult PartialLogin()
        {
            return PartialView("PartialLogin");
        }
    }
}