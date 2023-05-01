﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FruitSA_Dev_Test.DAL.Models
{
    public class RegisterUserModel : IdentityUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email Address is required")]
        public override string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}
