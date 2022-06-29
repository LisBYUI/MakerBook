using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IProfessionalAddressRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProfessionalAddressModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ProfessionalAddressModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        ProfessionalAddressModel Create(ProfessionalAddressModel professionalAddressModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        ProfessionalAddressModel Update(ProfessionalAddressModel professionalAddressModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
