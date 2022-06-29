using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class ProfessionalAddressRepository : IProfessionalAddressRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ProfessionalRepository
        /// </summary>
        /// <param name="context"></param>
        public ProfessionalAddressRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfessionalAddressModel Get(int id)
        {
            return _context.ProfessionalAddress.FirstOrDefault(i => i.ProfessionalAddressId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ProfessionalAddressModel> GetAll()
        {
            return _context.ProfessionalAddress.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="professionalAddressModel"></param>
        /// <returns></returns>
        public ProfessionalAddressModel Create(ProfessionalAddressModel professionalAddressModel)
        {
            _context.ProfessionalAddress.Add(professionalAddressModel);
            _context.SaveChanges();

            return professionalAddressModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProfessionalAddressModel Update(ProfessionalAddressModel professionalAddressModel)
        {
            ProfessionalAddressModel professionalAddressDb = Get(professionalAddressModel.ProfessionalAddressId);
            if (professionalAddressDb == null)
                throw new Exception("Record not Found");
            professionalAddressDb.LineAddress = professionalAddressModel.LineAddress;
            professionalAddressDb.ComplementAddress = professionalAddressModel.ComplementAddress;
            professionalAddressDb.City = professionalAddressModel.City;
            professionalAddressDb.State = professionalAddressModel.State;
            professionalAddressDb.Country = professionalAddressModel.Country;
            professionalAddressDb.ZipCode = professionalAddressModel.ZipCode;
            professionalAddressDb.Latitude = professionalAddressModel.Latitude;
            professionalAddressDb.Longitude = professionalAddressModel.Longitude;
            professionalAddressDb.UpdatedAt = professionalAddressModel.UpdatedAt;
            professionalAddressDb.UserAt = professionalAddressModel.UserAt;

            _context.ProfessionalAddress.Update(professionalAddressDb);
            _context.SaveChanges();

            return professionalAddressDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ProfessionalAddressModel professionalAddressDb = Get(id);
            if (professionalAddressDb == null)
                throw new Exception("Record not Found");

            _context.ProfessionalAddress.Remove(professionalAddressDb);
            _context.SaveChanges();

            return true;
        }


    }
}
