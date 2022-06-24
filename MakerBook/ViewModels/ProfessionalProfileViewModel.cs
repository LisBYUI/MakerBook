using MakerBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{

    public class ProfessionalProfileViewModel
    {
        [Display(Name = "ProfessionalProfile")]
        public int ProfessionalProfileId { get; set; }

        [Display(Name = "Professional")]
        public int ProfessionalId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public byte[]? ImageProfile { get; set; }


        [Display(Name = "A photo helps people recognize you")]
        public IFormFile? ImageProfileForm { get; set; }

        [Display(Name = "Facebook")]
        public string? Facebook { get; set; }

        [Display(Name = "Twitter")]
        public string? Twitter { get; set; }

        [Display(Name = "Google")]
        public string? Google { get; set; }

        [Display(Name = "Instagram")]
        public string? Instagram { get; set; }

        [Display(Name = "LinkedIn")]
        public string? Linkedin { get; set; }

        [Display(Name = "Pinterest")]
        public string? Pinterest { get; set; }

        [Display(Name = "YouTube")]
        public string? Youtube { get; set; }

        [Display(Name = "Slack")]
        public string? Slack { get; set; }

        [Display(Name = "GitHub")]
        public string? Github { get; set; }

        [Display(Name = "Reddit")]
        public string? Reddit { get; set; }

        [Display(Name = "WhatsApp")]
        public string? Whatsapp { get; set; }

        [Display(Name = "Skype")]
        public string? Skype { get; set; }

        public ProfessionalModel? Professional { get; set; }

        public List<ProfessionalSocialMediaModel> professionalSocialMediaList { get; set; }

        public List<ProfessionalServiceCardViewModel> professionalServiceCardViewList { get; set; }
    }
}
