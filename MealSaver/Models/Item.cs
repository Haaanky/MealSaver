using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string FoodItem { get; set; }
        public string ItemWeightMeasurement { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfInput { get; set; }
    }
}
