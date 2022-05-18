using MakerBook.Models;

namespace MakerBook.Helper
{
    public interface ISessionHelper
    {
        UserModel GetUserSession();
        void CreateUserSession(UserModel user);
        void DeleteUserSession();

    }
}
