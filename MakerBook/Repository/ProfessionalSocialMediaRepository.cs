using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class ProfessionalSocialMediaRepository: IProfessionalSocialMediaRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ProfessionalRepository
        /// </summary>
        /// <param name="context"></param>
        public ProfessionalSocialMediaRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfessionalSocialMediaModel Get(int id)
        {
            return _context.ProfessionalSocialMedia.FirstOrDefault(i => i.ProfessionalSocialMediaId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ProfessionalSocialMediaModel> GetAll()
        {
            return _context.ProfessionalSocialMedia.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalSocialMediaModel"></param>
        /// <returns></returns>
        public ProfessionalSocialMediaModel Create(ProfessionalSocialMediaModel professionalSocialMediaModel)
        {
            _context.ProfessionalSocialMedia.Add(professionalSocialMediaModel);
            _context.SaveChanges();

            return professionalSocialMediaModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalSocialMediaModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProfessionalSocialMediaModel Update(ProfessionalSocialMediaModel professionalSocialMediaModel)
        {
            ProfessionalSocialMediaModel professionalSocialMediaDb = Get(professionalSocialMediaModel.ProfessionalSocialMediaId);
            if (professionalSocialMediaDb == null)
                throw new Exception("Record not Found");

            professionalSocialMediaDb.SocialMedia = professionalSocialMediaModel.SocialMedia;
            professionalSocialMediaDb.UpdatedAt = professionalSocialMediaModel.UpdatedAt;
            professionalSocialMediaDb.UserAt = professionalSocialMediaModel.UserAt;

            _context.ProfessionalSocialMedia.Update(professionalSocialMediaDb);
            _context.SaveChanges();

            return professionalSocialMediaDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ProfessionalSocialMediaModel professionalSocialMediaDb = Get(id);
            if (professionalSocialMediaDb == null)
                throw new Exception("Record not Found");

            _context.ProfessionalSocialMedia.Remove(professionalSocialMediaDb);
            _context.SaveChanges();

            return true;
        }

        public List<ProfessionalSocialMediaModel> GetAllByProfessionalProfile(int ProfessionalProfileId)
        {
            return _context.ProfessionalSocialMedia.Where(w => w.ProfessionalProfileId == ProfessionalProfileId).ToList();
        }
    }
}
