using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{

    public class CustomerViewModel
    {
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail required")]
        [EmailAddress(ErrorMessage = "The email provided is not valid!")]
        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phonenumber required")]
        [Phone(ErrorMessage = "The phonenumber provided is not valid!")]
        public string PhoneNumber { get; set; }


    }
}
