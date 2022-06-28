using MakerBook.Enum;
using MakerBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.ViewModels
{

    public class ServiceViewModel
    {

        public int ServiceId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Service Type")]
        public ServiceTypeEnum ServiceType { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Professional")]
        public int ProfessionalId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string LineAddress { get; set; }

        [Display(Name = "Apartment, unit, suite, or floor")] 
        public string ComplementAddress { get; set; }

        [Display(Name = "Apartment, unit, suite, or floor")]
        public string City { get; set; }

        [Display(Name = "State/Province")]
        public string State { get; set; }
        [Display(Name = "Country/Region")]
        public string Country { get; set; }
        [Display(Name = "Postal Code")]
        public string ZipCode { get; set; }

        public ProfessionalModel? Professional { get; set; }
        public CategoryModel? Category { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }
        public List<SelectListItem>? ProfessionalList { get; set; }

        public List<IFormFile> ImageServiceList { get; set; }

        public List<ServiceImageViewModel>? ServiceImageList { get; set; }
    }
}
