﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    //public enum UnitMeasurement
    //{
    //    Kg,
    //    g,
    //    dL,
    //    L
    //}
    public class UserAddItemVM
    {
        [Display(Name = "Produkt")]
        [Required(ErrorMessage = "Välj vad du slängt")]
        public SelectListItem[] FoodItem { get; set; }
        [Range(1,3)]
        public int SelectedFoodValue { get; set; }

        [Display(Name = "Måttenhet")]
        public SelectListItem[] ItemWeight { get; set; }
        [Range(1, 3)]
        public int SelectedWeightValue { get; set; }

        //public UnitMeasurement Unit { get; set; }

        [Display(Name = "Mängd")]
        [Required(ErrorMessage = "Välj hur mycket du slängt")]
        
        public double Amount { get; set; }

        [Display(Name = "Datum")]
        public DateTime DateOfInput { get; set; }
    }
}
