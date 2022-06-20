using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Professional")]
    public class ProfessionalModel
    {
        [Column("ProfessionalId")]
        [Key]
        public int ProfessionalId { get; set; }
        [Column("Name")]
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
        [Column("LocationId")]
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Column("WebPage")]
        public string  WebPage { get; set; }
       
        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

       
    }
}
