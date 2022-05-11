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
        public string Name { get; set; }
        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Column("PhoneNumber")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}
