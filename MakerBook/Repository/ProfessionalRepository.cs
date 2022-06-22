using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class ProfessionalRepository: IProfessionalRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ProfessionalRepository
        /// </summary>
        /// <param name="context"></param>
        public ProfessionalRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfessionalModel Get(int id)
        {
            return _context.Professional.FirstOrDefault(i => i.ProfessionalId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ProfessionalModel> GetAll()
        {
            return _context.Professional.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        public ProfessionalModel Create(ProfessionalModel professionalModel)
        {
            _context.Professional.Add(professionalModel);
            _context.SaveChanges();

            return professionalModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProfessionalModel Update(ProfessionalModel professionalModel)
        {
            ProfessionalModel professionalDb = Get(professionalModel.ProfessionalId);
            if (professionalDb == null)
                throw new Exception("Record not Found");
            professionalDb.Name = professionalModel.Name;
            professionalDb.PhoneNumber = professionalModel.PhoneNumber;

            _context.Professional.Update(professionalDb);
            _context.SaveChanges();

            return professionalDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ProfessionalModel customerDb = Get(id);
            if (customerDb == null)
                throw new Exception("Record not Found");

            _context.Professional.Remove(customerDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
