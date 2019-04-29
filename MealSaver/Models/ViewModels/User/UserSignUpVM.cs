using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public class UserSignUpVM
    {
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
}
