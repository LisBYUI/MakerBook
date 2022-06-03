using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("ServiceImage")]
    public class ServiceImageModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public byte Image { get; set; }
        public int ServiceId { get; set; }
        public ServiceModel Service { get; set; }
    }
}
