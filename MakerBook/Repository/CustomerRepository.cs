using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MakerBook.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - CustomerRepository
        /// </summary>
        /// <param name="context"></param>
        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerModel Get(int id)
        {
            return _context.Customer.FirstOrDefault(i => i.CustomerId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<CustomerModel> GetAll()
        {
            return _context.Customer.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CustomerModel"></param>
        /// <returns></returns>
        public CustomerModel Create(CustomerModel customerModel)
        {
            _context.Customer.Add(customerModel);
            _context.SaveChanges();

            return customerModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CustomerModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CustomerModel Update(CustomerModel customerModel)
        {
            CustomerModel customerDb = Get(customerModel.CustomerId);
            if (customerDb == null)
                throw new Exception("Record not Found");
            customerDb.Name = customerModel.Name;
            customerDb.Email = customerModel.Email;
            customerDb.UpdatedAt = customerModel.UpdatedAt;
            customerDb.UserAt = customerModel.UserAt;

            _context.Customer.Update(customerDb);
            _context.SaveChanges();

            return customerDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            CustomerModel customerDb = Get(id);
            if (customerDb == null)
                throw new Exception("Record not Found");

            _context.Customer.Remove(customerDb);
            _context.SaveChanges();

            return true;
        }

        public CustomerModel GetByEmail(string email)
        {
            return _context.Customer.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

        }
    }
}
