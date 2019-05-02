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
        InfoService infoService;
        public InfoController(InfoService infoService)
        {
            this.infoService = infoService;
        }

        [Route("kontakt")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("om-mealsaver")]
        public IActionResult About()
        {
            return View(infoService.GetallFounders());
        }
    }
}