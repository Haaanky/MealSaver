﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.User
{
    public class UserSignUpVM
    {
        [Required]
        [Display(Name ="E-post")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Upprepa lösenord")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        public string Message { get; set; }
    }
}
