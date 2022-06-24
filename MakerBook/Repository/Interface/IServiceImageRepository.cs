using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IServiceImageRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceImageModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ServiceImageModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceImageModel"></param>
        /// <returns></returns>
        ServiceImageModel Create(ServiceImageModel serviceImageModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceImageModel"></param>
        /// <returns></returns>
        ServiceImageModel Update(ServiceImageModel serviceImageModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// GetByService
        /// </summary>
        /// <param name="idService"></param>
        /// <returns></returns>
        List<ServiceImageModel> GetByService(int idService);
    }
}
