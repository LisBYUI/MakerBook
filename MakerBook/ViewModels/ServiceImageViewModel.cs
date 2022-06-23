using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{
   
    public class ServiceImageViewModel
    {
        
        public int ServiceImageId { get; set; }

       
        public int Name { get; set; }

        
        public byte[] Image { get; set; }

      
        public int ServiceId { get; set; }

        public ServiceViewModel Service { get; set; }

    }
}
