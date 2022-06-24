using MakerBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{
  
    public class ServiceCardViewModel
    {

        public string ProfessionalName { get; set; }
        public byte[] ProfessionalImage { get; set; }

        public int ServiceId { get; set; }
        public int CategoryId { get; set; }
        public int ProfessionalId { get; set; }

        public string ServiceTitle { get; set; }


    }
}
