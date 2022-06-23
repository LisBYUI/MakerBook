using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IProfessionalSocialMediaRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProfessionalSocialMediaModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ProfessionalSocialMediaModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalSocialMediaModel"></param>
        /// <returns></returns>
        ProfessionalSocialMediaModel Create(ProfessionalSocialMediaModel professionalSocialMediaModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        ProfessionalSocialMediaModel Update(ProfessionalSocialMediaModel professionalSocialMediaModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

 
    }
}
