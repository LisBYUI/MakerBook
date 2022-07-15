using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IServiceAddressRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceAddressModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ServiceAddressModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceAddressModel"></param>
        /// <returns></returns>
        ServiceAddressModel Create(ServiceAddressModel serviceAddressModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceAddressModel"></param>
        /// <returns></returns>
        ServiceAddressModel Update(ServiceAddressModel serviceAddressModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        ServiceAddressModel GetByAddress(int idService);
    }
}
