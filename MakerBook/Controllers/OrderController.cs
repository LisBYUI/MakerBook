using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using MakerBook.Filters;
using MakerBook.Helper.Interface;
using MakerBook.ViewModels;

namespace MakerBook.Controllers
{
    [PageForUserLogged]
    public class OrderController : Controller
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IProfessionalProfileRepository _professionalProfileRepository;
        private readonly IProfessionalSocialMediaRepository _professionalSocialMediaRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerFavoriteServiceRepository _customerFavoriteServiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceImageRepository _serviceImageRepository; 
        private readonly IOrderRepository _orderRepository;
        private readonly ISessionHelper _session;


        public OrderController(IProfessionalRepository professionalRepository, IProfessionalProfileRepository professionalProfileRepository, IProfessionalSocialMediaRepository professionalSocialMediaRepository, IServiceRepository serviceRepository,
       IServiceImageRepository serviceImageRepository, ICategoryRepository categoryRepository, ICustomerFavoriteServiceRepository customerFavoriteServiceRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, ISessionHelper session)
        {
            _professionalRepository = professionalRepository;
            _professionalProfileRepository = professionalProfileRepository;
            _professionalSocialMediaRepository = professionalSocialMediaRepository;
            _serviceRepository = serviceRepository;
            _serviceImageRepository = serviceImageRepository;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
            _customerFavoriteServiceRepository = customerFavoriteServiceRepository;
            _orderRepository= orderRepository;
            _session = session;

        }

        // GET: OrderModel
        public IActionResult Index()
        {
            List<OrderModel> OrderList = _orderRepository.GetAll();
            List<OrderViewModel> orderViewList = new List<OrderViewModel>();

            foreach (var item in OrderList)
            {
                orderViewList.Add(MapRegisterOrderView(item));
            }

            return View(orderViewList);
        }

        // GET: OrderModel/Details/5
        public IActionResult Details(int? id)
        {
            var OrderModel = _orderRepository.Get(id ?? 0);

            if (OrderModel == null)
            {
                return NotFound();
            }

            var OrderViewModel = MapRegisterOrderView(OrderModel);

            return View(OrderViewModel);
        }

        // GET: OrderModel/Create
        public IActionResult Create(int id)
        {
            var OrderViewModel = new OrderViewModel();
            var userSession = _session.GetUserSession();

            if (userSession.Profile == Enum.ProfileEnum.Customer)
            {
                var customer = _customerRepository.GetByEmail(userSession.Email);

            }

                return View(OrderViewModel);
        }

        // POST: OrderModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel OrderViewModel)
        {
            try
            {
                var userSession = _session.GetUserSession();

               
                var OrderModel = MapRegisterOrder(OrderViewModel, userSession.Login);

                _orderRepository.Create(OrderModel);

                TempData["SuccessMessage"] = "Success!!!";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: OrderModel/Edit/5
        public IActionResult Edit(int? id)
        {
            var OrderModel = _orderRepository.Get(id ?? 0);
            if (OrderModel == null)
            {
                return NotFound();
            }

            var OrderViewModel = MapRegisterOrderView(OrderModel);

            return View(OrderViewModel);
        }

        // POST: OrderModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderViewModel OrderViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    byte[] file;
                    var filename = string.Empty;
                    var extension = string.Empty;

                   
                    var OrderModel = MapRegisterOrder(OrderViewModel, userSession.Login);

                    OrderModel Order = _orderRepository.Update(OrderModel);
                    TempData["SuccessMessage"] = "Success!!!";

                    return RedirectToAction(nameof(Index));
                }

                return View("Edit", OrderViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: OrderModel/Delete/5
        public IActionResult Delete(int? id)
        {
            var OrderModel = _orderRepository.Get(id ?? 0);
            if (OrderModel == null)
            {
                return NotFound();
            }

            var OrderViewModel = MapRegisterOrderView(OrderModel);

            return View(OrderViewModel);
        }

        // POST: OrderModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _orderRepository.Delete(id);
                if (deleteConfirmed)
                    TempData["SuccessMessage"] = "Success!!!";
                else
                    TempData["ErrorMessage"] = $"Fail!!!";

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// MapRegisterServiceView
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <returns></returns>
        private OrderViewModel MapRegisterOrderView(OrderModel sourceModel)
        {
            
            OrderViewModel targetModel = new OrderViewModel
            {
                OrderId = sourceModel.OrderId
            ,
                Date = sourceModel.Date
            ,
                PaymentType = sourceModel.PaymentType
            
            };

            return targetModel;
        }

        /// <summary>
        /// MapRegisterOrder
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private OrderModel MapRegisterOrder(OrderViewModel sourceModel, string login)
        {
            OrderModel targetModel = new OrderModel
            {
                OrderId = sourceModel.OrderId
            ,
                Date = sourceModel.Date
            ,
                PaymentType = sourceModel.PaymentType
            ,
                ServiceId = sourceModel.ServiceId
            ,
                CustomerId = sourceModel.CustomerId
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };

            return targetModel;
        }
    }
}
