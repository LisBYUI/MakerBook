using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Address")]
    public class AddressModel
    {
        [Column("AddressId")]
        [Key]
        public int AddressId { get; set; }

        [Column("LineAddress")]
        public string LineAddress { get; set; }

        [Column("ComplementAddress")]
        public string ComplementAddress { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("CustomerId")]
        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


        public CustomerModel Customer { get; set; }
    }
}
