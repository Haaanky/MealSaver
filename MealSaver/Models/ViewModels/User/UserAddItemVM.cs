using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public enum UnitMeasurement
    {
        Kg,
        g,
        dL,
        L
    }
    public class UserAddItemVM
    {
        [Display(Name = "Produkt")]
        public SelectListItem[] FoodArray { get; set; }
        [Range(1,3)]
        public int SelectedFoodValue { get; set; }

        [Display(Name = "Mängd")]
        public double ItemAmount { get; set; }
        public UnitMeasurement Unit { get; set; }
        public DateTime DateOfInput { get; set; }
    }

}
