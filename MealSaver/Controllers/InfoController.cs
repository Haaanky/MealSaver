using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class InfoController : Controller
    {

        [Route("kontakt")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("om-mealsaver")]
        public IActionResult About()
        {
            return View();
        }
    }
}