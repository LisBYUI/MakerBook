namespace MakerBook.Helper.Interface
{
    public interface IEmail
    {
        bool Send(string email, string subject, string message);
    }
}
