using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    [Table("Order")]
    public class OrderModel
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel? Customer { get; set; }
    }
}
