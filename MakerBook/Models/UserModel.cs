using MakerBook.Enum;
using MakerBook.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("User")]
    public class UserModel
    {
        [Column("UserId")]
        [Display(Name = "UserId")]
        [Key]
        public int UserId { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

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


        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

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
