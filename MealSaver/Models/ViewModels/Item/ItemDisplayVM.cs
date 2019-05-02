using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public class ItemDisplayVM
    {
        public string Type { get; set; }
        public double AmountKg { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{Type}, {AmountKg}, {Date.ToShortDateString()}";
        }
    }
}