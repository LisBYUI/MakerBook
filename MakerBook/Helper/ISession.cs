using MakerBook.Models;

namespace MakerBook.Helper
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void UpdateUserSession(UserModel user);
        void DeleteUserSession();
        UserModel GetUserSession();
    }
}
