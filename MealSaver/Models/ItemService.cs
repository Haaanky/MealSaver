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
            switch (item.SelectedWeightValue)
            {
                case 3: item.Amount /= 1000; break;
                case 5: item.Amount /= 10; break;
                default:
                    break;
            }
            switch (item.SelectedFoodValue)
            {
                case 1: item.Type = "Välj"; break;
                case 2: item.Type = "Mjölk"; break;
                case 3: item.Type = "Kött"; break;
                case 4: item.Type = "Frukt"; break;
                default:
                    break;
            }
            foodObjContext.Products.Add(new Products
            {

                Type = item.Type,
                AmountKg = item.Amount,
                Date = item.DateOfInput,
                UserId = currentUserID //lägg till så att vi kan koppla slängd mat till användaren 
            });
            await foodObjContext.SaveChangesAsync();
        }
    
            public ItemDisplayVM[] GetAllItems(string currentUserID)
            {
                return foodObjContext.Products
                    .OrderByDescending(o => o.Date)
                    .Where(o => o.UserId == currentUserID)
                    .Select(o => new ItemDisplayVM
                    {
                        //Type = o.Type,
                        //AmountKg = o.AmountKg,
                        //Date = o.Date
                        Type  = o.Type,
                        AmountKg = o.AmountKg,
                        Date = o.Date,
                        
                    })
                    .ToArray();
            }
    }
}
