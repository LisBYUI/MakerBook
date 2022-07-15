using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class ServiceAddressRepository : IServiceAddressRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ServiceRepository
        /// </summary>
        /// <param name="context"></param>
        public ServiceAddressRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceAddressModel Get(int id)
        {
            return _context.ServiceAddress.FirstOrDefault(i => i.ServiceAddressId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ServiceAddressModel> GetAll()
        {
            return _context.ServiceAddress.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceAddressModel"></param>
        /// <returns></returns>
        public ServiceAddressModel Create(ServiceAddressModel serviceAddressModel)
        {
            _context.ServiceAddress.Add(serviceAddressModel);
            _context.SaveChanges();

            return serviceAddressModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceAddressModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ServiceAddressModel Update(ServiceAddressModel serviceAddressModel)
        {
            ServiceAddressModel serviceAddressDb = Get(serviceAddressModel.ServiceAddressId);
            if (serviceAddressDb == null)
                throw new Exception("Record not Found");
            serviceAddressDb.LineAddress = serviceAddressModel.LineAddress;
            serviceAddressDb.ComplementAddress = serviceAddressModel.ComplementAddress;
            serviceAddressDb.City = serviceAddressModel.City;
            serviceAddressDb.State = serviceAddressModel.State;
            serviceAddressDb.Country = serviceAddressModel.Country;
            serviceAddressDb.ZipCode = serviceAddressModel.ZipCode;
            serviceAddressDb.Latitude = serviceAddressModel.Latitude;
            serviceAddressDb.Longitude = serviceAddressModel.Longitude;
            serviceAddressDb.UpdatedAt = serviceAddressModel.UpdatedAt;
            serviceAddressDb.UserAt = serviceAddressModel.UserAt;

            _context.ServiceAddress.Update(serviceAddressDb);
            _context.SaveChanges();

            return serviceAddressDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ServiceAddressModel serviceAddressDb = Get(id);
            if (serviceAddressDb == null)
                throw new Exception("Record not Found");

            _context.ServiceAddress.Remove(serviceAddressDb);
            _context.SaveChanges();

            return true;
        }

        public ServiceAddressModel GetByAddress(int idService)
        {
            return _context.ServiceAddress.FirstOrDefault(i => i.ServiceId == idService);
        }

    }
}
