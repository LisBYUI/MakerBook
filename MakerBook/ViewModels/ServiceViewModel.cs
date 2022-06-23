using MakerBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MakerBook.ViewModels
{
    
    public class ServiceViewModel
    {
       
        public int ServiceId { get; set; }

        
        public string Description { get; set; }

        public double Price { get; set; }

       
        public int ProfessionalId { get; set; }

       
        public int CategoryId { get; set; }

        public ProfessionalModel? Professional { get; set; }
        public CategoryModel? Category { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }
        public List<SelectListItem>? ProfessionalList { get; set; }

        public List<IFormFile> ImageServiceList { get; set; }

        public List<ServiceImageViewModel> ServiceImageList { get; set; }
    }
}
