using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("ProfessionalProfile")]
    public class ProfessionalProfileModel
    {
        [Column("ProfessionalProfileId")]
        [Key]
        public int ProfessionalProfileId { get; set; }

        [Column("ProfessionalId")]
        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }

        [Column("ImageProfile")]
        public byte[] ImageProfile { get; set; }

      
        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        public ProfessionalModel Professional { get; set; }
    }
}
