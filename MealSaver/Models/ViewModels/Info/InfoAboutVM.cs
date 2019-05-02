﻿using MealSaver.Models.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models.ViewModels.Info
{
    public class InfoAboutVM
    {
        public UserLoginVM LoginVM { get; set; }
        public InfoListVM[] ListVM { get; set; }
    }
}
