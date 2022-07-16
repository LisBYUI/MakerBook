using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<OrderModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="OrderModel"></param>
        /// <returns></returns>
        OrderModel Create(OrderModel orderModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="OrderModel"></param>
        /// <returns></returns>
        OrderModel Update(OrderModel orderModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// GetByProfessional
        /// </summary>
        /// <param name="professionalId"></param>
        /// <returns></returns>
        List<OrderModel> GetByProfessional(int professionalId);

        /// <summary>
        /// GetByCustomer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<OrderModel> GetByCustomer(int customerId);
    }
}
