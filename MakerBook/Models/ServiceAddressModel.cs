using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("ServiceAddress")]
    public class ServiceAddressModel
    {
        [Column("ServiceAddressId")]
        [Key]
        public int ServiceAddressId { get; set; }

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

        [Column("ServiceId")]
        [ForeignKey("ServiceId")]
        public int? ServiceId { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

    }
}
