using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealSaver.Models.ViewModels.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealSaver.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        [HttpGet]
        [Route("oversikt")]
        public IActionResult Overview()
        {
            return View();
        }

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