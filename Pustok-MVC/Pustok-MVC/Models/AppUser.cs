﻿using Microsoft.AspNetCore.Identity;

namespace Pustok_MVC.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRemained {  get; set; }
    }
}
