using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("ServiceImage")]
    public class ServiceImageModel
    {
        [Column("ServiceImageId")]
        [Key]
        public int ServiceImageId { get; set; }

        [Column("Name")]
        public int Name { get; set; }

        [Column("Image")]
        public byte[] Image { get; set; }

        [Column("ServiceId")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
      
        public ServiceModel Service { get; set; }

    }
}
