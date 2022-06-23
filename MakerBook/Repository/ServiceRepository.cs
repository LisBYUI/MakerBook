using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ServiceRepository
        /// </summary>
        /// <param name="context"></param>
        public ServiceRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceModel Get(int id)
        {
            return _context.Service.FirstOrDefault(i => i.ServiceId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ServiceModel> GetAll()
        {
            return _context.Service.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceModel"></param>
        /// <returns></returns>
        public ServiceModel Create(ServiceModel serviceModel)
        {
            _context.Service.Add(serviceModel);
            _context.SaveChanges();

            return serviceModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ServiceModel Update(ServiceModel serviceModel)
        {
            ServiceModel serviceDb = Get(serviceModel.ServiceId);
            if (serviceDb == null)
                throw new Exception("Record not Found");
            serviceDb.Price = serviceModel.Price;
            serviceDb.Description = serviceModel.Description;
            serviceDb.UpdatedAt = serviceModel.UpdatedAt;
            serviceDb.UserAt = serviceModel.UserAt;

            _context.Service.Update(serviceDb);
            _context.SaveChanges();

            return serviceDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ServiceModel serviceDb = Get(id);
            if (serviceDb == null)
                throw new Exception("Record not Found");

            _context.Service.Remove(serviceDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
