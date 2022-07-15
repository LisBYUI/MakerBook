using System.ComponentModel;

namespace MakerBook.Enum
{
    public enum StatusOrderEnum
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Processing")]
        Processing = 1,
        [Description("Completed")]
        Completed = 2, 
        [Description("Canceled ")]
        Canceled = 3

    }
}
