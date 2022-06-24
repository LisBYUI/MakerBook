using MakerBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{

    public class ProfessionalServiceCardViewModel
    {
        public int ProfessionalProfileId { get; set; }

        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Title")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Description")]
        public string ServiceDescription { get; set; }

        [Display(Name = "Image")]
        public byte[] ImageProfile { get; set; }

    }
}
