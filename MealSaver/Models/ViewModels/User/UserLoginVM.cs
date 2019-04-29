using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public class UserLoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
