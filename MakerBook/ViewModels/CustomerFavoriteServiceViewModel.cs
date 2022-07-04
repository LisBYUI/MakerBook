using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.Models
{
    public class CustomerFavoriteServiceViewModel
    {
        
        public int CustomerFavoriteServiceId { get; set; }

        public string? Feedback { get; set; }
        public int? Rate { get; set; }

        public DateTime CreatedAt { get; set; }
        public int ServiceId { get; set; }

        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

    }
}
