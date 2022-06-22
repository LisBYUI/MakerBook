using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.Models
{
    [Table("Position")]
    public class PositionModel
    {
        [Column("PositionId")]
        [Key]
        public int PositionId { get; set; }

        [Column("Latitude")]
        public int Latitude { get; set; }
        [Column("Longitude")]
        public int Longitude { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

    }
}
