using MealSaver.Models;
using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Views.Shared.Components.AboutUs
{
    public class LoginViewComponent : ViewComponent
    {
        private InfoService service;
        public LoginViewComponent(InfoService service)
        {
            this.service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new UserLoginVM());
        }
    }
}
