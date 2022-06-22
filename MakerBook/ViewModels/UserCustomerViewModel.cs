using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{
    public class UserCustomerViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "The email provided is not valid!")]
        public string Email { get; set; }


        public string? WebPage { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone Number required")]
        [Phone(ErrorMessage = "The phonenumber provided is not valid!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login required")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        [MaxLength(16, ErrorMessage = "The maximum length of the {0} field is {1} characters.")]
        [MinLength(6, ErrorMessage = "The minimum length of the {0} field is {1} characters.")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Confirmation required")]
        [MaxLength(16, ErrorMessage = "The maximum length of the {0} field is {1} characters.")]
        [MinLength(6, ErrorMessage = "The minimum length of the {0} field is {1} characters.")]
        [Compare(nameof(Password), ErrorMessage = "Password confirmation does not match the password.")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "Profile")]
        public ProfileEnum Profile { get; set; }
    }
}
