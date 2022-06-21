using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<CustomerModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CustomerModel"></param>
        /// <returns></returns>
        CustomerModel Create(CustomerModel customerModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CustomerModel"></param>
        /// <returns></returns>
        CustomerModel Update(CustomerModel customerModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
