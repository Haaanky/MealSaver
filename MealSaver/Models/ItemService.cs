using MealSaver.Models.Entities;
using MealSaver.Models.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class ItemService
    {
        public ItemService(FoodObjContext foodObjContext)
        {
            this.foodObjContext = foodObjContext;
        }

        private readonly FoodObjContext foodObjContext;

        public async Task AddItem(Item item, string currentUserID)
        {
            switch (item.SelectedFoodValue)
            {
                case 1: item.Type = ProductType.Fisk; break;
                case 2: item.Type = ProductType.Frukt; break;
                case 3: item.Type = ProductType.Färdigmat; break;
                case 4: item.Type = ProductType.Grönsaker; break;
                case 5: item.Type = ProductType.Konserver; break;
                case 6: item.Type = ProductType.Kött; break;
                case 7: item.Type = ProductType.Mejeriprodukter; break;
                case 8: item.Type = ProductType.Rotfrukter; break;
                case 9: item.Type = ProductType.Spannmål; break;
                case 10: item.Type = ProductType.Övrigt; break;
                default:
                    break;
            }

            switch (item.SelectedWeightValue)
            {
                case 1: item.UnitOfMeasurement = UnitMeasurement.Kg; break;
                case 2: item.UnitOfMeasurement = UnitMeasurement.g; break;
                case 3: item.UnitOfMeasurement = UnitMeasurement.L; break;
                case 4: item.UnitOfMeasurement = UnitMeasurement.dL; break;
                default:
                    break;
            }

            foodObjContext.Products.Add(new Products
            {

                Type = item.Type.ToString(),
                UnitOfMeasurement = item.UnitOfMeasurement.ToString(),
                Amount = item.Amount,
                Date = item.DateOfInput,
                UserId = currentUserID
            });
            await foodObjContext.SaveChangesAsync();
        }

        internal double GetTotalAmountForUser(string userId)
        {
            return foodObjContext.Products
                .Where(o => o.UserId == userId /*&& o.Type == "Frukt"*/)
                .Sum(o => o.Amount);
        }
        internal double GetTotalAmountForUser(string userId, ProductType productType)
        {
            return foodObjContext.Products
                .Where(o => o.UserId == userId && o.Type == productType.ToString())
                .Sum(o => o.Amount);
        }

        internal double GetTotalAmount()
        {
            return foodObjContext.Products
                .Sum(o => o.Amount);
        }

        public ItemDisplayVM[] GetAllItems(string currentUserID)
        {
            var prodArr = foodObjContext.Products
                .OrderByDescending(o => o.Date)
                .Where(o => o.UserId == currentUserID)
                .Select(o => new ItemDisplayVM
                {
                    Type = Enum.Parse<ProductType>(o.Type),
                    Amount = o.Amount,
                    Date = o.Date,
                    UnitOfMeasurement = Enum.Parse<UnitMeasurement>(o.UnitOfMeasurement)
                })
                .ToArray();
            //prodArr = NormalizeData(prodArr);
            return prodArr;
        }

        //public ItemDisplayVM[] NormalizeData(ItemDisplayVM[] arr)
        //{
        //    foreach (var item in arr) // normalize database amount to kg/L
        //    {
        //        switch (item.UnitOfMeasurement)
        //        {
        //            case UnitMeasurement.g: item.Amount /= 1000; break;
        //            case UnitMeasurement.dL: item.Amount /= 10; break;
        //            default:
        //                break;
        //        }
        //    }
        //    return arr;
        //}
        public ItemDisplayNormalizedVM[] NormalizeDataNormalVM(ItemDisplayVM[] arr)
        {
            ItemDisplayNormalizedVM[] items = new ItemDisplayNormalizedVM[arr.Length];
            for (int i = 0; i < arr.Length; i++) // normalize database amount to kg/L
            {
                ItemDisplayVM item = (ItemDisplayVM)arr[i];
                items[i] = new ItemDisplayNormalizedVM { Amount = item.Amount, Type = item.Type, UnitOfMeasurement = item.UnitOfMeasurement};
                switch (items[i].UnitOfMeasurement)
                {
                    case UnitMeasurement.g: items[i].Amount /= 1000; break;
                    case UnitMeasurement.dL: items[i].Amount /= 10; break;
                    default:
                        break;
                }
            }
            return items;
        }
    }
}
