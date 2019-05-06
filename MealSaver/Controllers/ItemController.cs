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
using System.Security.Claims;

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
            var prodArr = itemService.GetAllItems(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            double totalAmount = 0;

            foreach (var item in prodArr)
            {
                totalAmount += item.Amount;
            }

            var itemOverviewVM = new ItemOverviewVM
            {
                Message = (string)TempData["Message"],
                FirstName = HttpContext.User.Identity.Name,
                TotalAmount = totalAmount,
                ItemList = prodArr
            };

            return View(itemOverviewVM);
        }

        [HttpGet]
        public IActionResult Form()
        {
            return Redirect("/lagga-till");
        }

        [HttpPost]
        public async Task<IActionResult> Form(/*ItemAddVM userAddItemVM*/Item item)
        {
            var currentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await itemService.AddItem(item, currentUserID);

            return Redirect("/lagga-till");
        }

        [HttpGet]
        [Route("lagga-till")]
        public IActionResult Add()
        {
            var currentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ItemAddVM itemAddVM = new ItemAddVM
            {
                FormVM = new ItemFormVM
                {
                    //lägg till fler alternativ
                    FoodItem = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "0", Text = "Välj", Disabled = true, Selected = true }/*,*/
                        //new SelectListItem { Value = "1", Text = ProductType.Mjölk.ToString() },
                        //new SelectListItem { Value = "2", Text = ProductType.Kött.ToString() },
                        //new SelectListItem { Value = "3", Text = ProductType.Frukt.ToString() }
                    },

                    ItemWeightMeasurement = new SelectListItem[]
                    {
                        new SelectListItem { Value = "0", Text = "Välj", Disabled = true, Selected = true },
                        new SelectListItem { Value = "1", Text = UnitMeasurement.Kg.ToString() },
                        new SelectListItem { Value = "2", Text = UnitMeasurement.g.ToString() },
                        new SelectListItem { Value = "3", Text = UnitMeasurement.L.ToString() },
                        new SelectListItem { Value = "4", Text = UnitMeasurement.dL.ToString() }
                    }
                },
                ItemList = itemService.GetAllItems(currentUserID)
                //new ItemDisplayVM[]
                //{
                //    new ItemDisplayVM
                //    {
                //        Type = "Potatis",
                //        AmountKg = 5,
                //        Date = DateTime.Now.Date

                //    }
                //}
            };

            var tmpArr = new List<string>();
            foreach (ProductType foo in Enum.GetValues(typeof(ProductType)))
            {
                tmpArr.Add(foo.ToString());
            }
            for (int i = 0; i < tmpArr.Count; i++)
            {
                itemAddVM.FormVM.FoodItem.Add(new SelectListItem { Value = (i + 1).ToString(), Text = tmpArr[i].ToString() });
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