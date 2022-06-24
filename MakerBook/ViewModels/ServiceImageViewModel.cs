using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{
   
    public class ServiceImageViewModel
    {
        
        public int ServiceImageId { get; set; }

        [Display(Name = "Filename")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        public ServiceViewModel Service { get; set; }

    }
}
