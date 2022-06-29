using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - OrderRepository
        /// </summary>
        /// <param name="context"></param>
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderModel Get(int id)
        {
            return _context.Order.FirstOrDefault(i => i.OrderId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<OrderModel> GetAll()
        {
            return _context.Order.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="OrderModel"></param>
        /// <returns></returns>
        public OrderModel Create(OrderModel OrderModel)
        {
            _context.Order.Add(OrderModel);
            _context.SaveChanges();

            return OrderModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="OrderModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public OrderModel Update(OrderModel orderModel)
        {
            OrderModel OrderDb = Get(orderModel.OrderId);
            if (OrderDb == null)
                throw new Exception("Record not Found");
            OrderDb.Date = orderModel.Date;
            OrderDb.PaymentType = orderModel.PaymentType;

            _context.Order.Update(OrderDb);
            _context.SaveChanges();

            return OrderDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            OrderModel OrderDb = Get(id);
            if (OrderDb == null)
                throw new Exception("Record not Found");

            _context.Order.Remove(OrderDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
