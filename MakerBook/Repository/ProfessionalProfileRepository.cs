using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class ProfessionalProfileRepository: IProfessionalProfileRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ProfessionalProfileRepository
        /// </summary>
        /// <param name="context"></param>
        public ProfessionalProfileRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfessionalProfileModel Get(int id)
        {
            return _context.ProfessionalProfile.FirstOrDefault(i => i.ProfessionalProfileId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ProfessionalProfileModel> GetAll()
        {
            return _context.ProfessionalProfile.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        public ProfessionalProfileModel Create(ProfessionalProfileModel professionalProfileModel)
        {
            _context.ProfessionalProfile.Add(professionalProfileModel);
            _context.SaveChanges();

            return professionalProfileModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalProfileModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProfessionalProfileModel Update(ProfessionalProfileModel professionalProfileModel)
        {
            ProfessionalProfileModel professionalProfileDb = Get(professionalProfileModel.ProfessionalProfileId);
            if (professionalProfileDb == null)
                throw new Exception("Record not Found");

            professionalProfileDb.ImageProfile = professionalProfileModel.ImageProfile;
            professionalProfileDb.UpdatedAt = professionalProfileModel.UpdatedAt;
            professionalProfileDb.UserAt = professionalProfileModel.UserAt;

            _context.ProfessionalProfile.Update(professionalProfileDb);
            _context.SaveChanges();

            return professionalProfileDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ProfessionalProfileModel professionalProfileDb = Get(id);
            if (professionalProfileDb == null)
                throw new Exception("Record not Found");

            _context.ProfessionalProfile.Remove(professionalProfileDb);
            _context.SaveChanges();

            return true;
        }

       
    }
}
