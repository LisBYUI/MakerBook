using System.ComponentModel;

namespace MakerBook.Enum
{
    public enum ServiceTypeEnum
    {
        [Description("Online / Local")]
        OnlineOrLocal = 0,
        [Description("Online")]
        Online = 1,
        [Description("Local")]
        Local = 2

    }
}
