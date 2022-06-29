using MakerBook.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{

    public class OrderViewModel
    {
        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Payment")]
        public PaymentTypeEnum PaymentType { get; set; }
    

     
    }
}
