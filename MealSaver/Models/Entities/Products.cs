using System;
using System.Collections.Generic;

namespace MealSaver.Models.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string UnitOfMeasurement { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}