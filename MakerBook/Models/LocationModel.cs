using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Location")]
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }

        public int PositionId { get; set; }
        public CustomerModel Customer { get; set; }
        public PositionModel Position { get; set; }
    }
}
