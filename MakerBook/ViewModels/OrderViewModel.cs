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

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }


        [Display(Name = "Professional")]
        public int ProfessionalId { get; set; }

        [Display(Name = "Category Service")]
        public int CategoryId { get; set; }

        [Display(Name = "Payment")]
        public PaymentTypeEnum PaymentType { get; set; }


        [Display(Name = "Service")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Detail")]
        public string? ServiceDescription { get; set; }

        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        public Enum.StatusOrderEnum Status { get; set; }

        [Display(Name = "Price")]
        public string? ServicePrice { get; set; }
        public string? Address { get; set; }
        public List<SelectListItem>? CategoryList { get; set; }
        public List<SelectListItem>? ProfessionalList { get; set; }
        public List<SelectListItem>? ServiceList { get; set; }
        [Display(Name = "Professional")]
        public string? ProfessionalName { get; set; }
        [Display(Name = "E-mail")]
        public string? ProfessionalEmail { get; set; }
        [Display(Name = "Customer")]
        public string? CustomerName { get; set; }

        public ProfileEnum Profile { get; set; }
    }
}
