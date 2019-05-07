using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public class ItemDisplayNormalizedVM
    {

        public ProductType Type { get; set; }
        public double Amount { get; set; }
        public UnitMeasurement UnitOfMeasurement { get; set; }
        public DateTime Date { get; set; }
        //public static implicit operator ItemDisplayNormalizedVM(ItemDisplayVM itemDisplayVM)
        //{
        //    return new ItemDisplayVM
        //    {
        //        Amount = itemDisplayVM.Amount,
        //        Type = itemDisplayVM.Type,
        //        UnitOfMeasurement = itemDisplayVM.UnitOfMeasurement
        //    };
        //}
        public override string ToString()
        {
            return $"{Type}, {Amount}, {UnitOfMeasurement}, {Date.ToShortDateString()}";
        }
    }
}