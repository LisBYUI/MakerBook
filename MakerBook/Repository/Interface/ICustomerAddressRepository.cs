using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface ICustomerAddressRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerAddressModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<CustomerAddressModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        CustomerAddressModel Create(CustomerAddressModel professionalAddressModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        CustomerAddressModel Update(CustomerAddressModel professionalAddressModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
