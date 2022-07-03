using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("CustomerFavoriteService")]
    public class CustomerFavoriteServiceModel
    {
        [Column("CustomerFavoriteServiceId")]
        [Key]
        public int CustomerFavoriteServiceId { get; set; }

        public string? Feedback { get; set; }
        public int? Rate { get; set; }

        [Column("ServiceId")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

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
        public ServiceModel Service { get; set; }
    }
}
