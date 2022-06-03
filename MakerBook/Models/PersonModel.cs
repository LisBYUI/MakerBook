using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Person")]
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
