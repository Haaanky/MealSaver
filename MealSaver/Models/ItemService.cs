using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class ItemService
    {
        //byt ut denna när vi lägger till items i databasen
        //static int idCounter = 3;
        //private static List<Item> thrownItems = new List<Item>
        //{
        //    new Item{ Id= 1, FoodItem = "Frukt", Amount = 3, ItemWeightMeasurement= "Kg", DateOfInput = DateTime.Now},
        //    new Item{ Id= 2, FoodItem = "Kött", Amount = 666, ItemWeightMeasurement= "g", DateOfInput = DateTime.Now},
        //    new Item{ Id= 3, FoodItem = "Mjölk", Amount = 50, ItemWeightMeasurement= "L", DateOfInput = DateTime.Now}

        //};

        //public void AddItem(Item item)
        //{
        //    item.Id = ++idCounter;
        //    thrownItems.Add(item);
        //}
        //public Item[] GetAllItems()
        //{
        //    return thrownItems.ToArray();
        //}

        //public ItemService(MealSaverDBContext context)
        //{
        //    this.context = context;
        //}

        //private readonly MealSaverDBContext context;

        //public async Task AddPerson(ItemAddVM item)
        //{
        //    context.Contact.Add(new Item
        //    {
        //        Name = item.Name,
        //    });
        //    await context.SaveChangesAsync();
        //}
    }
}
