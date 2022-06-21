﻿using MakerBook.Enum;
using MakerBook.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("User")]
    public class UserModel
    {
        [Column("Id")]
        [Display(Name = "Identifier")]
        public int Id { get; set; }
        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Column("Login")]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Column("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Column("Profile")]
        [Display(Name = "Profile")]
        public ProfileEnum Profile { get; set; }

        public bool ValidPassword(string password)
        {
            return Password == password.GenerateHash();
        }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }

        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.GenerateHash();
            return newPassword;
        }

    }
}
