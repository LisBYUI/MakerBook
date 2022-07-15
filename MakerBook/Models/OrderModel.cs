using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Order")]
    public class OrderModel

         
    {
        [Column("OrderId")]
        [Key]
        public int OrderId { get; set; }

        [Column("OrderDate")]
        public DateTime Date { get; set; }

        [Column("CustomerId")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("ServiceId")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Column("PaymentType")]
        public PaymentTypeEnum PaymentType { get; set; }

        [Column("Status")]
        public StatusOrderEnum Status { get; set; }

        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


        public CustomerModel? Customer { get; set; }
        public ServiceModel? Service { get; set; }
    }
}
