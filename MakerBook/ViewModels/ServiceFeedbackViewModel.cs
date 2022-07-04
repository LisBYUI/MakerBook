using MakerBook.Enum;
using MakerBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.ViewModels
{

    public class ServiceFeedbackViewModel
    {

        public int ServiceId { get; set; }

        [Display(Name = "Title")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Service Type")]
        public ServiceTypeEnum ServiceType { get; set; }

        public string ProfessionalName { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State/Province")]
        public string State { get; set; }
        [Display(Name = "Country/Region")]
        public string Country { get; set; }
        [Display(Name = "Postal Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
        public List<CustomerFavoriteServiceViewModel> CustomerFavoriteServiceViewList { get; set; }



    }
}
