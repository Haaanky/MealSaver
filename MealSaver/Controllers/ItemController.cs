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
        private readonly ItemService itemService;
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
            var itemsArray = itemService.GetAllItems();
            var itemOverviewVM = new ItemOverviewVM
            {
                //FirstName = HttpContext.Session.GetString("Name"),
                //Username = cache.Get<string>("supportEmail"),
                Message = (string)TempData["Message"],
                FirstName = HttpContext.User.Identity.Name
            };


            return View(itemOverviewVM);
        }


        //[Route("lagga-till")]
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View(itemService.GetAllItems());
        //}

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(/*ItemAddVM userAddItemVM*/Item item)
        {
            await itemService.AddItem(item);

            //return RedirectToAction(nameof(Add));
            return View();
        }

        [HttpGet]
        [Route("lagga-till")]
        public IActionResult Add()
        {
            ItemAddVM itemAddVM = new ItemAddVM
            {
                FormVM = new ItemFormVM
                {
                    //lägg till fler alternativ
                    FoodItem = new SelectListItem[]
                    {
                        new SelectListItem { Value = "1", Text = "Välj", Selected = true },
                        new SelectListItem { Value = "2", Text = "Mjölk" },
                        new SelectListItem { Value = "3", Text = "Kött" },
                        new SelectListItem { Value = "4", Text = "Frukt" }
                    },

                    ItemWeightMeasurement = new SelectListItem[]
                    {
                        new SelectListItem { Value = "1", Text = "Välj", Selected = true },
                        new SelectListItem { Value = "2", Text = "Kg" },
                        new SelectListItem { Value = "3", Text = "g" },
                        new SelectListItem { Value = "4", Text = "L" },
                        new SelectListItem { Value = "5", Text = "dl" }
                    }
                },
                ItemList = new ItemDisplayVM[]
                {
                    new ItemDisplayVM
                    {
                        Type = "Potatis",
                        AmountKg = 5,
                        Date = DateTime.Now.Date
                    
                    }
                }
                

            };
            return View(itemAddVM);
        }

        [HttpGet]
        public IActionResult Display(ItemDisplayVM itemDisplayVM)
        {
            return View(itemDisplayVM);
        }
    }
}