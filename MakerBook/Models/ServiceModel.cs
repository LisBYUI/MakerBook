using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.Models
{
    [Table("Service")]
    public class ServiceModel
    {
        [Column("ServiceId")]
        [Key]
        public int ServiceId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Price")]
        public double Price { get; set; }
        [Column("ProfessionalId")]
        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }
        [Column("CategoryId")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


        public ProfessionalModel Professional { get; set; }
        public CategoryModel Category { get; set; }

    }
}
