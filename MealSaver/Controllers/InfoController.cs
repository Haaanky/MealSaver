using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.Info;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class InfoController : Controller
    {
        InfoService sv;
        public InfoController(InfoService service)
        {
            sv = service;
        }

        [Route("kontakt")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("om-mealsaver")]
        public IActionResult About()
        {
            InfoAboutVM infoAboutVM = new InfoAboutVM() {
                ListVM = sv.GetallFounders(),
                LoginVM = new Models.ViewModels.User.UserLoginVM()
            };
            //sv.GetallFounders()
            return View(infoAboutVM);
        }
        public IActionResult PartialLogin()
        {
            return PartialView("PartialLogin");
        }
    }
}