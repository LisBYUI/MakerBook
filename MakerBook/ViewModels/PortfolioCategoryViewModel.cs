using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerBook.ViewModels
{

    public class PortfolioCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public byte[]? CategoryImage { get; set; }

        public List<ServiceCardViewModel> ServiceCardViewList { get; set; }
    }
}
