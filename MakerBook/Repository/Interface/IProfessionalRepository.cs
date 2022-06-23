using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IProfessionalRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProfessionalModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ProfessionalModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        ProfessionalModel Create(ProfessionalModel professionalModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        ProfessionalModel Update(ProfessionalModel professionalModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        ProfessionalModel GetByEmail(string email);
    }
}
