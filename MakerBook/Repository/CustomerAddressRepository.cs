using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ProfessionalRepository
        /// </summary>
        /// <param name="context"></param>
        public CustomerAddressRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerAddressModel Get(int id)
        {
            return _context.CustomerAddress.FirstOrDefault(i => i.CustomerAddressId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<CustomerAddressModel> GetAll()
        {
            return _context.CustomerAddress.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="customerAddressModel"></param>
        /// <returns></returns>
        public CustomerAddressModel Create(CustomerAddressModel customerAddressModel)
        {
            _context.CustomerAddress.Add(customerAddressModel);
            _context.SaveChanges();

            return customerAddressModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ProfessionalAddressModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CustomerAddressModel Update(CustomerAddressModel customerAddressModel)
        {
            CustomerAddressModel customerAddressDb = Get(customerAddressModel.CustomerAddressId);
            if (customerAddressDb == null)
                throw new Exception("Record not Found");
            customerAddressDb.LineAddress = customerAddressModel.LineAddress;
            customerAddressDb.ComplementAddress = customerAddressModel.ComplementAddress;
            customerAddressDb.City = customerAddressModel.City;
            customerAddressDb.State = customerAddressModel.State;
            customerAddressDb.Country = customerAddressModel.Country;
            customerAddressDb.ZipCode = customerAddressModel.ZipCode;
            customerAddressDb.Latitude = customerAddressModel.Latitude;
            customerAddressDb.Longitude = customerAddressModel.Longitude;
            customerAddressDb.UpdatedAt = customerAddressModel.UpdatedAt;
            customerAddressDb.UserAt = customerAddressModel.UserAt;

            _context.CustomerAddress.Update(customerAddressDb);
            _context.SaveChanges();

            return customerAddressDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            CustomerAddressModel customerAddressDb = Get(id);
            if (customerAddressDb == null)
                throw new Exception("Record not Found");

            _context.CustomerAddress.Remove(customerAddressDb);
            _context.SaveChanges();

            return true;
        }


    }
}
