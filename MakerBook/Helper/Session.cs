using MakerBook.Models;

namespace MakerBook.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContex;

        public  Session(IHttpContextAccessor httpContex)
        {
            _httpContex = httpContex;
        }

        public void CreateUserSession(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserSession()
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserSession()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserSession(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
