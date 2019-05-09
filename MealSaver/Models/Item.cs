using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
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
        Fisk,
        [Display(Name ="Frukt och Bär")]
        Frukt,
        Färdigmat,
        Grönsaker,
        Konserver,
        Kött,
        Mejeriprodukter,
        Rotfrukter,
        [Display(Name ="Bröd och Spannmål")]
        Spannmål,
        Övrigt
    }
    public class Item
    {
        public ProductType Type { get; set; }
        public string Amount { get; set; }
        public UnitMeasurement UnitOfMeasurement { get; set; }
        public DateTime DateOfInput { get; set; }
        public int SelectedFoodValue { get; set; }
        public int SelectedWeightValue { get; set; }
        public SelectListItem[] FoodItem { get; set; }
        public SelectListItem[] ItemWeightMeasurement { get; set; }
    }
}
