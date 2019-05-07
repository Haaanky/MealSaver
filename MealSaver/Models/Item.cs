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
        Mejeriprodukter,
        Kött,
        Fisk,
        [Display(Name ="Bröd och Spannmål")]
        Spannmål,
        [Display(Name ="Frukt och Bär")]
        Frukt,
        Grönsaker,
        Rotfrukter,
        Konserver,
        Färdigmat,
        Övrigt
    }
    public class Item
    {
        public ProductType Type { get; set; }
        public double Amount { get; set; }
        public UnitMeasurement UnitOfMeasurement { get; set; }
        public DateTime DateOfInput { get; set; }
        public int SelectedFoodValue { get; set; }
        public int SelectedWeightValue { get; set; }
        public SelectListItem[] FoodItem { get; set; }
        public SelectListItem[] ItemWeightMeasurement { get; set; }
    }
}
