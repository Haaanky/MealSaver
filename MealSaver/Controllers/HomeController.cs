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
    }
}