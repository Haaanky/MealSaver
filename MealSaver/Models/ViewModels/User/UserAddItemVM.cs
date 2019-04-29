using System;
using System.Collections.Generic;
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
        public string ItemName { get; set; }
        public double ItemAmount { get; set; }
        public UnitMeasurement Unit { get; set; }
        public DateTime DateOfInput { get; set; }
    }
}
