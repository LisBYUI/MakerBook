using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Column("CategoryId")]
        [Key]
        public int CategoryId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Image")]
        public byte[] Image { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
        [NotMapped]
        public IFormFile ImageCategory { get; set; }
    }
}
