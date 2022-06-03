using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.Models
{
    [Table("Position")]
    public class PositionModel
    {
        public int Id { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}
