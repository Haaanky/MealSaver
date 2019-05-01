using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models.Entities;
using MealSaver.Models;
using MealSaver.Models.ViewModels.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace MealSaver.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        IMemoryCache cache;
        public ItemController(ItemService itemService, IMemoryCache cache)
        {
            this.itemService = itemService;
            this.cache = cache;
        }
        [HttpGet]
        [Route("oversikt")]
        public IActionResult Overview()
        {
            UserSignUpVM userSignUpVM = new UserSignUpVM();


            userSignUpVM.FirstName = HttpContext.Session.GetString("Name");
            userSignUpVM.Username = cache.Get<string>("supportEmail");
            userSignUpVM.Message = (string)TempData["Message"];

            return View(userSignUpVM);
        }

        private readonly ItemService itemService;

        //[Route("lagga-till")]
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View(itemService.GetAllItems());
        //}

        [HttpGet]
        [Route("lagga-till")]
        public IActionResult Add()
        {
            var viewModel = new ItemAddVM
            {
                //lägg till fler alternativ
                FoodItem = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Välj", Selected = true},
                    new SelectListItem {Value = "2", Text = "Mjölk"},
                    new SelectListItem {Value = "3", Text = "Kött"},
                    new SelectListItem {Value = "4", Text = "Frukt"}
                },

                ItemWeightMeasurement = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Välj", Selected = true},
                    new SelectListItem {Value = "2", Text = "Kg"},
                    new SelectListItem {Value = "3", Text = "g"},
                    new SelectListItem {Value = "4", Text = "L"},
                    new SelectListItem {Value = "5", Text = "dl"}
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("lagga-till")]
        public IActionResult AddItem(ItemAddVM userAddItemVM)
        {
            return RedirectToAction(nameof(AddItem));
        }
    }
}