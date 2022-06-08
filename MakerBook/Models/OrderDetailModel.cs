using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("OrderDetail")]
    public class OrderDetailModel
    {
        [Column("OrderDetailId")]
        [Key]
        public int OrderDetailId { get; set; }
        [Column("OrderId")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Column("ServiceId")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


        public OrderModel Order { get; set; }
        public ServiceModel Service { get; set; }
       

    }
}
