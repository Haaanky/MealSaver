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
using System.Data;

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

        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {

            }
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
                ItemList = itemService.NormalizeDataNormalVM(prodArr)
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
            var itemList = itemService.GetAllItems(currentUserID);
            var itemListNormalized = itemService.NormalizeDataNormalVM(itemList);

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
                ItemList = itemList,
                ItemListNormalized = itemListNormalized
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

        [HttpPost]
        public IActionResult TypePieChart()
        {
            var currentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var type = "Type";
            string amount = "Amount";

            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add(type, System.Type.GetType("System.String"));
            dt.Columns.Add(amount, System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();

            var typeArr = new List<ProductType>();
            foreach (ProductType item in Enum.GetValues(typeof(ProductType)))
            {
                typeArr.Add(item);
            }

            for (int i = 0; i < typeArr.Count; i++)
            {
                dr = dt.NewRow();
                dr[type] = typeArr[i];
                dr[amount] = itemService.GetTotalAmountForUser(currentUserID, typeArr[i]);
                if (itemService.GetTotalAmountForUser(currentUserID, typeArr[i]) != 0)
                {
                    dt.Rows.Add(dr);
                }
            }

            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData);
        }

        public IActionResult DateBarChart()
        {
            var currentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var date = "Date";
            string amount = "Amount";

            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add(date, System.Type.GetType("System.String"));
            dt.Columns.Add(amount, System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();

            var dateArr = new List<DateTime>();
            foreach (var item in itemService.GetAllDates(currentUserID))
            {
                dateArr.Add(item.Date);
            }

            for (int i = 0; i < dateArr.Count; i++)
            {
                dr = dt.NewRow();
                dr[date] = dateArr[i];
                dr[amount] = itemService.GetTotalAmountForUser(currentUserID, dateArr[i]);
                if (itemService.GetTotalAmountForUser(currentUserID, dateArr[i]) != 0)
                {
                    dt.Rows.Add(dr);
                }
            }

            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData);
        }
    }
}