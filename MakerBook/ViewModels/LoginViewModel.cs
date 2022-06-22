using System.ComponentModel.DataAnnotations;

namespace MakerBook.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login required") ]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
