﻿using System.ComponentModel.DataAnnotations;

namespace MakerBook.Models
{
    public class RecoverPasswordModel
    {
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "E-mail required")]
        public string Email { get; set; }
    }
}
