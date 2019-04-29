using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class UserService
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        //public void ShowDropdownItems()
        //{
        //    var viewModel = new UserAddItemVM
        //    {
        //        FoodArray = new SelectListItem[]
        //        {
        //            new SelectListItem {Value = 1, Text = "Välj", Selected = true},
        //            new SelectListItem {Value = 2, Text = "Mjölk"},
        //            new SelectListItem {Value = 3, Text = "Kött"},
        //            new SelectListItem {Value = 4, Text = "Frukt"}
        //        }
        //    };
        //}
    }
}
