using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class ServiceImageRepository: IServiceImageRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ServiceImageRepository
        /// </summary>
        /// <param name="context"></param>
        public ServiceImageRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceImageModel Get(int id)
        {
            return _context.ServiceImage.FirstOrDefault(i => i.ServiceImageId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ServiceImageModel> GetAll()
        {
            return _context.ServiceImage.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceImageModel"></param>
        /// <returns></returns>
        public ServiceImageModel Create(ServiceImageModel serviceImageModel)
        {
            _context.ServiceImage.Add(serviceImageModel);
            _context.SaveChanges();

            return serviceImageModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceImageModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ServiceImageModel Update(ServiceImageModel serviceImageModel)
        {
            ServiceImageModel serviceImageDb = Get(serviceImageModel.ServiceImageId);
            if (serviceImageDb == null)
                throw new Exception("Record not Found");
            serviceImageDb.Name = serviceImageModel.Name;
            serviceImageDb.Image = serviceImageModel.Image;
            serviceImageDb.UpdatedAt = serviceImageModel.UpdatedAt;
            serviceImageDb.UserAt = serviceImageModel.UserAt;  

            _context.ServiceImage.Update(serviceImageDb);
            _context.SaveChanges();

            return serviceImageDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ServiceImageModel serviceImageDb = Get(id);
            if (serviceImageDb == null)
                throw new Exception("Record not Found");

            _context.ServiceImage.Remove(serviceImageDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
