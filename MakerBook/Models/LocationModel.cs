using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Location")]
    public class LocationModel
    {
        [Column("LocationId")]
        [Key]
        public int LocationId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    
        [Column("PositionId")]
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


 
        public PositionModel Position { get; set; }
    }
}
