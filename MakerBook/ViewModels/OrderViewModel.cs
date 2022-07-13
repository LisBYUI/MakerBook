using MakerBook.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        [Display(Name = "Service")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Detail")]
        public string ServiceDescription { get; set; }

        [Display(Name = "Service Type")]
        public ServiceTypeEnum ServiceType { get; set; }

        [Display(Name = "Price")]
        public double ServicePrice { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }
        public List<SelectListItem>? ProfessionalList { get; set; }

    }
}
