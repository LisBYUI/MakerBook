using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserModel Get(int id);

        UserModel GetByLogin(string login);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<UserModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        UserModel Create(UserModel userModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        UserModel Update(UserModel userModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        UserModel GetByEmailLogin(string email, string login);
    }
}
