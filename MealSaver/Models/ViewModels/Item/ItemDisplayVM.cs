﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public class ItemDisplayVM
    {

        public ProductType Type { get; set; }
        public double Amount { get; set; }
        public UnitMeasurement UnitOfMeasurement { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{Type}, {Amount}, {UnitOfMeasurement}, {Date.ToShortDateString()}";
        }
    }
}