using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.Models
{
    [Table("Service")]
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfessionalId { get; set; }
        public ProfessionalModel Professional { get; set; }
    }
}
