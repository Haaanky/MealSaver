using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Item
{
    public class ItemAddVM
    {
        public ItemFormVM FormVM { get; set; }
        public ItemDisplayVM[] ItemList { get; set; }
        public ItemDisplayNormalizedVM[] ItemListNormalized { get; set; }
    }
}
