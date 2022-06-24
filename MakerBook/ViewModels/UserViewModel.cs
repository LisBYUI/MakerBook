using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{

    public class UserViewModel
    {

        [Display(Name = "User")]
        public int UserId { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail required")]
        [EmailAddress(ErrorMessage = "The email provided is not valid!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        [MaxLength(16, ErrorMessage = "The maximum length of the {0} field is {1} characters.")]
        [MinLength(6, ErrorMessage = "The minimum length of the {0} field is {1} characters.")]
        public string Password { get; set; }

        [Column("Profile")]
        [Display(Name = "Profile")]
        public ProfileEnum Profile { get; set; }


    }
}
