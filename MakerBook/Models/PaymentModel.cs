using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Payment")]
    public class PaymentModel
    {
        [Column("PaymentId")]
        [Key]
        public int PaymentId { get; set; }

        [Column("PaymentType")]
        public PaymentTypeEnum PaymentType { get; set; }
        
        [Column("UserAt")]
        public string UserAt { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

    }
}
