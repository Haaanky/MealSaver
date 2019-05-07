using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService userService;
        private readonly ItemService itemService;

        public HomeController(UserService userService, ItemService itemService)
        {
            this.userService = userService;
            this.itemService = itemService;
        }

        [Route("")]
        public IActionResult Index()
        {
            //throw new Exception("Fel! Error Error Error");
            var homeIndexVM = new HomeIndexVM { TotalWaste = itemService.GetTotalAmount()};
            return View(homeIndexVM);
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
        [Route("SocialMedia")]
        public IActionResult PartialSocialMedia()
        {
            return PartialView("_PartialSocialMedia");
        }
    }
}