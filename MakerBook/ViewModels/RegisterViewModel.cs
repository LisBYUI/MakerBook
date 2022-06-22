using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.Models
{
    public class RegisterViewModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-mail required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Display(Name = "Profile")]
        public ProfileEnum Profile { get; set; }
    }
}
