using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class CustomerFavoriteServiceRepository : ICustomerFavoriteServiceRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - CustomerFavoriteServiceRepository
        /// </summary>
        /// <param name="context"></param>
        public CustomerFavoriteServiceRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerFavoriteServiceModel Get(int id)
        {
            return _context.CustomerFavoriteService.FirstOrDefault(i => i.CustomerFavoriteServiceId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<CustomerFavoriteServiceModel> GetAll()
        {
            return _context.CustomerFavoriteService.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CustomerFavoriteServiceModel"></param>
        /// <returns></returns>
        public CustomerFavoriteServiceModel Create(CustomerFavoriteServiceModel customerFavoriteServiceModel)
        {
            _context.CustomerFavoriteService.Add(customerFavoriteServiceModel);
            _context.SaveChanges();

            return customerFavoriteServiceModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CustomerFavoriteServiceModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CustomerFavoriteServiceModel Update(CustomerFavoriteServiceModel customerFavoriteServiceModel)
        {
            CustomerFavoriteServiceModel customerFavoriteServiceDb = Get(customerFavoriteServiceModel.CustomerFavoriteServiceId);
            if (customerFavoriteServiceDb == null)
                throw new Exception("Record not Found");
            customerFavoriteServiceDb.Feedback = customerFavoriteServiceModel.Feedback;
            customerFavoriteServiceDb.Rate = customerFavoriteServiceModel.Rate;
   
            customerFavoriteServiceDb.UpdatedAt = customerFavoriteServiceModel.UpdatedAt;
            customerFavoriteServiceDb.UserAt = customerFavoriteServiceModel.UserAt;

            _context.CustomerFavoriteService.Update(customerFavoriteServiceDb);
            _context.SaveChanges();

            return customerFavoriteServiceDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            CustomerFavoriteServiceModel CustomerFavoriteServiceDb = Get(id);
            if (CustomerFavoriteServiceDb == null)
                throw new Exception("Record not Found");

            _context.CustomerFavoriteService.Remove(CustomerFavoriteServiceDb);
            _context.SaveChanges();

            return true;
        }

        public CustomerFavoriteServiceModel GetByCustomerService(int customerId, int serviceId)
        {
            return _context.CustomerFavoriteService.FirstOrDefault(i => i.CustomerId == customerId && i.ServiceId == serviceId);
        }
    }
}
