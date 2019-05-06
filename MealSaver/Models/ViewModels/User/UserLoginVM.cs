using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "E-posten matchar inte")]
        [Display(Name ="E-mail")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lösenordet matchar inte")]
        [Display(Name ="Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public static implicit operator UserLoginVM(UserSignUpVM userSignUpVM)
        {
            return new UserLoginVM
            {
                Username = userSignUpVM.Username,
                Password = userSignUpVM.Password
            };
        }
    }
}
