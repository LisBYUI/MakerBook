using MakerBook.Helper.Interface;
using MakerBook.Models;
using Newtonsoft.Json;

namespace MakerBook.Helper
{
    public class SessionHelper : ISessionHelper
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContext;

        /// <summary>
        /// Construtor - Session
        /// </summary>
        /// <param name="httpContext"></param>
        public SessionHelper(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        /// <summary>
        /// GetUserSession
        /// </summary>
        /// <returns></returns>
        public UserModel GetUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(userSession))
                return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        /// <summary>
        /// CreateUserSession
        /// </summary>
        /// <param name="user"></param>
        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("sessionUserLogged", value);
        }

        /// <summary>
        /// DeleteUserSession
        /// </summary>
        public void DeleteUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessionUserLogged");
        }
    }
}
