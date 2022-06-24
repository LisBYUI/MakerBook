using MakerBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MakerBook.ViewModels
{
    public class PortfolioViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public byte[]? CategoryImage { get; set; }

        public List<ServiceCardViewModel> ServiceCardViewList { get; set; }
        
    }

}
