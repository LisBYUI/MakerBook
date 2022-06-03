using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Professional")]
    public class ProfessionalModel:PersonModel
    {
        public int Id { get; set; }
       
    }
}
