using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{
    public class RecoverPasswordViewModel
    {
        [Display(Name = "Log in")]
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail required")]
        public string Email { get; set; }
    }
}
