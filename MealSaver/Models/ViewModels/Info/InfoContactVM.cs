using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Info
{
    public class InfoContactVM
    {
        [Display(Name = "Namn")]
        [Required(ErrorMessage = "Ange ditt namn")]
        public string Name { get; set; }
        [Display(Name = "E-post")]
        [Required(ErrorMessage = "E-post krävs för att vi ska kunna kontakta dig")]
        [EmailAddress(ErrorMessage = "Felaktig E-post")]
        public string Email { get; set; }
        [Display(Name = "Din fråga")]
        public string Description { get; set; }
    }
}
