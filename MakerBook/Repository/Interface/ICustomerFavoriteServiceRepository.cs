using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface ICustomerFavoriteServiceRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerFavoriteServiceModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<CustomerFavoriteServiceModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CustomerFavoriteServiceModel"></param>
        /// <returns></returns>
        CustomerFavoriteServiceModel Create(CustomerFavoriteServiceModel customerFavoriteServiceModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CustomerFavoriteServiceModel"></param>
        /// <returns></returns>
        CustomerFavoriteServiceModel Update(CustomerFavoriteServiceModel customerFavoriteServiceModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// GetByCustomerService
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        CustomerFavoriteServiceModel GetByCustomerService(int customerId, int serviceId);
    }
}
