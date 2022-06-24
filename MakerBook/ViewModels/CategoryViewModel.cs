using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{

    public class CategoryViewModel
    {
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public byte[]? Image { get; set; }

        [Display(Name = "Filename")]
        public string? ImageName { get; set; }

        [Display(Name = "Extension")]
        public string? ImageExtension { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageCategory { get; set; }
    }
}
