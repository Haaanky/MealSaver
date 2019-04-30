using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public class UserLoginVM
    {
        [Required]
        [Display(Name ="E-mail")]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [Display(Name ="Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
