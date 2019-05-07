using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public class ItemOverviewVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public double TotalAmount { get; set; }
        public string UnitOfMeasurement { get; private set; }
        public DateTime Date { get; set; }
        public ItemDisplayNormalizedVM[] ItemList { get; set; }
    }
}
