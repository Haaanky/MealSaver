using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class Item
    {
        public string Type { get; set; }
        //private string type;

        //public string Type
        //{
        //    get { return type; }
        //    set {
        //        switch (SelectedFoodValue)
        //        {
        //            case 1: type = "Välj"; break;
        //            case 2: type = "Mjölk"; break;
        //            case 3: type = "Kött"; break;
        //            case 4: type = "Frukt"; break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        public double Amount { get; set; }
        //public string UserId { get; set; }
        public DateTime DateOfInput { get; set; }
        //public string ItemWeightMeasurement { get; set; }
        public int SelectedFoodValue { get; set; }
        public int SelectedWeightValue { get; set; }
        public SelectListItem[] FoodItem { get; set; }
        public SelectListItem[] ItemWeightMeasurement { get; set; }
    }
}
