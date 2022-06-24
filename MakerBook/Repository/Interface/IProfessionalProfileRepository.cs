using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IProfessionalProfileRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProfessionalProfileModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ProfessionalProfileModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalProfileModel"></param>
        /// <returns></returns>
        ProfessionalProfileModel Create(ProfessionalProfileModel professionalProfileModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalProfileModel"></param>
        /// <returns></returns>
        ProfessionalProfileModel Update(ProfessionalProfileModel professionalProfileModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        ProfessionalProfileModel GetByProfessional(int professionalId);
    }
}
