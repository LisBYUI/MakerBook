using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("CustomerAddress")]
    public class CustomerAddressModel
    {
        [Column("CustomerAddressId")]
        [Key]
        public int CustomerAddressId { get; set; }

        [Column("LineAddress")]
        public string LineAddress { get; set; }

        [Column("ComplementAddress")]
        public string ComplementAddress { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Latitude")]
        public double Latitude { get; set; }

        [Column("Longitude")]
        public double Longitude { get; set; }

        [Column("CustomerId")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
