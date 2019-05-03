using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MealSaver.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/servererror")]
        public IActionResult ServerError()
        {
            return View();
        }

        [Route("error/httpError/{id}")]
        public IActionResult HttpError(int id)
        {
            return View(id);
        }
    }
}