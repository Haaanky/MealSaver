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
    }
}
