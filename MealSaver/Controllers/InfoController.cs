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
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("kontakt")]
        [HttpPost]
        public async Task<IActionResult> Contact(InfoContactVM infoContactVM)
        {
            await infoService.AddContactFormToDBAsync(infoContactVM);
            return RedirectToAction(nameof(Contact));
        }
        [Route("om-mealsaver")]
        public IActionResult About()
        {
            return View(infoService.GetallFounders());
        }
    }
}