using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("OrderDetail")]
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
    }
}
