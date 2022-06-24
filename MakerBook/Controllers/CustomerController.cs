using Microsoft.AspNetCore.Mvc;
using MakerBook.Models;
using MakerBook.Filters;
using MakerBook.Helper.Interface;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;

namespace MakerBook.Controllers
{
    [RestrictedPageAdminOnly]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISessionHelper _session;

        /// <summary>
        /// CustomerController
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="session"></param>
        public CustomerController(ICustomerRepository customerRepository, ISessionHelper session)
        {
            _customerRepository = customerRepository;
            _session = session;
        }

        // GET: Customer
        public IActionResult Index()
        {
            List<CustomerModel> customerList = _customerRepository.GetAll();

            List<CustomerViewModel> customerViewList = new List<CustomerViewModel>();

            foreach (var customer in customerList)
            {
                customerViewList.Add(MapRegisterCustomerView(customer));
            }


            return View(customerViewList);
        }

        // GET: Customer/Details/5
        public IActionResult Details(int? id)
        {
            var customerModel = _customerRepository.Get(id ?? 0);

            if (customerModel == null)
            {
                return NotFound();
            }
            var customerViewModel = MapRegisterCustomerView(customerModel);

            return View(customerViewModel);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    CustomerModel customerModel = MapRegisterCustomer(customerViewModel, userSession.Login);

                    _customerRepository.Create(customerModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }
                return View(customerViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Customer/Edit/5
        public IActionResult Edit(int? id)
        {
            var customerModel = _customerRepository.Get(id ?? 0);
            if (customerModel == null)
            {
                return NotFound();
            }

            CustomerViewModel customerViewModel = MapRegisterCustomerView(customerModel);

            return View(customerViewModel);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    CustomerModel customerModel = MapRegisterCustomer(customerViewModel, userSession.Login);

                    _customerRepository.Update(customerModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Editar", customerViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: Customer/Delete/5
        public IActionResult Delete(int? id)
        {
            var customerModel = _customerRepository.Get(id ?? 0);
            if (customerModel == null)
            {
                return NotFound();
            }
            CustomerViewModel customerViewModel = MapRegisterCustomerView(customerModel);

            return View(customerViewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _customerRepository.Delete(id);
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
        /// MapRegisterCustomerView
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static CustomerViewModel MapRegisterCustomerView(CustomerModel sourceModel)
        {
            CustomerViewModel targetModel = new CustomerViewModel
            {
                CustomerId = sourceModel.CustomerId
            ,
                Name = sourceModel.Name
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                Email = sourceModel.Email

            };


            return targetModel;
        }

        /// <summary>
        /// MapRegisterUser
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static CustomerModel MapRegisterCustomer(CustomerViewModel sourceModel, string login)
        {
            CustomerModel targetModel = new CustomerModel
            {
                CustomerId = sourceModel.CustomerId
            ,
                Name = sourceModel.Name
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                Email = sourceModel.Email
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
