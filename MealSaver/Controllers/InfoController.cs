using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models;
using MealSaver.Models.ViewModels.Info;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MealSaver.Controllers
{
    public class InfoController : Controller
    {
        InfoService infoService;
        private readonly IConfiguration _configuration;

        public InfoController(InfoService infoService, IConfiguration _configuration)
        {
            this.infoService = infoService;
            this._configuration = _configuration;
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
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Contact));
            if (!InfoService.ReCaptchaPassed(
            Request.Form["g-recaptcha-response"], // that's how you get it from the Request object
            _configuration.GetSection("GoogleReCaptcha:secret").Value
            ))
            {
                ModelState.AddModelError(nameof(infoContactVM.ReCAPTCHA), "You failed the CAPTCHA, stupid robot.");
                return View(infoContactVM);
            }
            await infoService.AddContactFormToDBAsync(infoContactVM);
            return RedirectToAction(nameof(Contact));
        }
        [Route("om-mealsaver")]
        public IActionResult About()
        {
            return View(infoService.GetallFounders());
        }
        public IActionResult Credits()
        {
            return View();
        }
    }
}