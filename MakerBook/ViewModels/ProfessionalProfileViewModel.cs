using MakerBook.Models;

namespace MakerBook.ViewModels
{

    public class ProfessionalProfileViewModel
    {
        public int ProfessionalProfileId { get; set; }

        public int ProfessionalId { get; set; }

        public byte[] ImageProfile { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Pinterest { get; set; }
        public string Youtube { get; set; }
        public string Slack { get; set; }
        public string Github { get; set; }
        public string Reddit { get; set; }
        public string Whatsapp { get; set; }

        public ProfessionalModel? Professional { get; set; }
    }
}
