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
        [Column("NumberOrder")]
        public string NumberOrder { get; set; }
        [Column("PaymentId")]
        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        [Column("UserAt")]
        public string UserAt { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }


        public CustomerModel Customer { get; set; }
        public PaymentModel? Payment { get; set; }
    }
}
