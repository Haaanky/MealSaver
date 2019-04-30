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
        public async Task<IdentityResult> TryRegisterAsync(UserSignUpVM userSignUpVM)
        {
            return await userManager.CreateAsync(new MyIdentityUser { UserName = userSignUpVM.Username }, userSignUpVM.Password);
        }

        internal async Task<SignInResult> TryLoginAsync(UserLoginVM userLoginVM)
        {
            return await signInManager.PasswordSignInAsync(
                userLoginVM.Username,
                userLoginVM.Password,
                isPersistent: false,
                lockoutOnFailure: false
                );
        }
        internal async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        //static int idCounter = 3;
        //private static List<UserAddItemVM> thrownItems = new List<UserAddItemVM>
        //{
        //    new UserAddItemVM{ Id= 1, FoodItem = }
        //};
    }
}
