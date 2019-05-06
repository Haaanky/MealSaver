using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public enum UnitMeasurement
    {
        Kg,
        g,
        dL,
        L
    }
    public enum ProductType
    {
        Mjölk,
        Kött,
        Frukt
    }
    public class ItemFormVM
    {
        [Display(Name = "Produkt")]
        [Required(ErrorMessage = "Välj vad du slängt")]
        public SelectListItem[] FoodItem { get; set; }
        [Range(1,10)]
        public int SelectedFoodValue { get; set; }

        [Display(Name = "Måttenhet")]
        [Required(ErrorMessage = "Ange en måttenhet")]

        public SelectListItem[] ItemWeightMeasurement { get; set; }
        [Range(1, 10)]
        public int SelectedWeightValue { get; set; }

        [Display(Name = "Mängd")]
        [Range(0.1, 999)]
        [Required(ErrorMessage = "Välj hur mycket du slängt")]
        
        public double Amount { get; set; }

        [Display(Name = "Datum")]
        public DateTime DateOfInput { get; set; } = DateTime.Now.Date;
    }
}
