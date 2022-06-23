using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{

    public class CategoryViewModel
    {
        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public byte[]? Image { get; set; }

        public string? ImageName { get; set; }

        public string? ImageExtension { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageCategory { get; set; }
    }
}
