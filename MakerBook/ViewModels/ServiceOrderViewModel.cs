using MakerBook.Enum;
using MakerBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.ViewModels
{

    public class ServiceOrderViewModel
    {

        public int ServiceId { get; set; }


        [Display(Name = "Service")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Detail")]
        public string ServiceDescription { get; set; }

        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Professional")]
        public int ProfessionalId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string? LineAddress { get; set; }

        [Display(Name = "Apartment, unit, suite, or floor")] 
        public string? ComplementAddress { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "State/Province")]
        public string? State { get; set; }
        [Display(Name = "Country/Region")]
        public string? Country { get; set; }
        [Display(Name = "Postal Code")]
        public string? ZipCode { get; set; }
        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }
        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }
        [Display(Name = "Professional")]
        public string ProfessionalName { get; set; }
        [Display(Name = "E-mail")]
        public string ProfessionalEmail { get; set; }

    }
}
