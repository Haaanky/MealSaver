using System;
using System.Collections.Generic;

namespace MealSaver.Models.Entities
{
    public partial class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
        public string ReCAPTCHA { get; set; }
    }
}
