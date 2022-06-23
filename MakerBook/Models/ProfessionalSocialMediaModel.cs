using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("ProfessionalSocialMedia")]
    public class ProfessionalSocialMediaModel
    {
        [Column("ProfessionalSocialMediaId")]
        [Key]
        public int ProfessionalSocialMediaId { get; set; }

        [Column("ProfessionalProfileId")]
        [ForeignKey("ProfessionalProfile")]
        public int ProfessionalProfileId { get; set; }

        [Column("SocialMedia")]
        public string SocialMedia { get; set; }

        [Column("ProfessionalProfileType")]
        public ProfessionalProfileTypeEnum ProfessionalProfileType { get; set; }

      
        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        public ProfessionalProfileModel ProfessionalProfile { get; set; }
    }
}
