using MakerBook.Models;

namespace MakerBook.Helper.Interface
{
    public interface ISessionHelper
    {
        UserModel GetUserSession();
        void CreateUserSession(UserModel user);
        void DeleteUserSession();

    }
}
