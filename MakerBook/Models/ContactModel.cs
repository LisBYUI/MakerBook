using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Contact")]
    public class ContactModel
    {
        [Column("Id")]
        [Display(Name = "Identifier")]
        public int Id { get; set; }
        [Column("Name")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Provide the name")]
        public string Name { get; set; }
        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "provide the email")]
        [EmailAddress(ErrorMessage = "The email provided is not valid!")]
        public string Email { get; set; }
        [Column("PhoneNumber")]
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "provide the phonenumber")]
        [Phone(ErrorMessage = "The phonenumber provided is not valid!")]
        public string PhoneNumber { get; set; }
    }
}
