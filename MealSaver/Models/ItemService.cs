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
        public ItemService(FoodObjContext context)
        {
            this.context = context;
        }

        private readonly FoodObjContext context;

        public async Task AddItem(Item item)
        {
            switch (item.ItemWeightMeasurement)
            {
                case "g": item.Amount /= 1000; break;
                case "dl": item.Amount /= 10; break;
                default:
                    break;
            }
            context.Products.Add(new Products
            {
                Type = item.FoodItem,
                AmountKg = item.Amount,
                Date = item.DateOfInput,
                //UserId =  //lägg till så att vi kan koppla slängd mat till användaren 
            });
            await context.SaveChangesAsync();
        }
    
            public Item[] GetAllItems()
            {
                return context.Products
                    .OrderByDescending(o => o.Date)
                    .Select(o => new Item
                    {
                        //Type = o.Type,
                        //AmountKg = o.AmountKg,
                        //Date = o.Date
                        FoodItem  = o.Type,
                        Amount = o.AmountKg,
                        DateOfInput = o.Date,
                        
                    })
                    .ToArray();
            }
    }
}
