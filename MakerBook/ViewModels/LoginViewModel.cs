using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Log in")]
        [Required(ErrorMessage = "Login required") ]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
