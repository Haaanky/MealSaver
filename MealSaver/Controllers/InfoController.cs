using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
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
            return View(sv.GetallFounders());
        }
    }
}